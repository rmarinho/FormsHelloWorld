#!/usr/bin/env bash

if [ -n "$1" ]; then
  echo "android api: $1"
  ANDROID_API_IMAGE="system-images;$1;google_apis;x86"
else
  echo "No android api version supplied falling back to api27"
  ANDROID_API_IMAGE="system-images;android-api27;google_apis;x86"
fi

echo "android api: $ANDROID_API_IMAGE"

# Install AVD files
echo "y" | $ANDROID_HOME/tools/bin/sdkmanager --install $ANDROID_API_IMAGE

# # Create emulator
echo "no" | $ANDROID_HOME/tools/bin/avdmanager create avd -n xamarin_android_emulator -k $ANDROID_API_IMAGE --force

$ANDROID_HOME/emulator/emulator -list-avds

echo "Starting emulator"

# Start emulator in background
nohup $ANDROID_HOME/emulator/emulator -avd xamarin_android_emulator -no-snapshot > /dev/null 2>&1 &
$ANDROID_HOME/platform-tools/adb wait-for-device shell 'while [[ -z $(getprop sys.boot_completed | tr -d '\r') ]]; do sleep 1; done; input keyevent 82'

$ANDROID_HOME/platform-tools/adb devices

echo "Emulator started"
