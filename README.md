# HelloWorld
 Testing Flutter/ Xamarin Android / Xamarin Forms startup time


Running Xamarin.Forms project
`profile-android.ps1 -project HelloForms/HelloForms.Android/HelloForms.Android.csproj -configuration Release -extra /p:USE_XAMLC=true -xamarinformsversion 4.8.0.1364 -package com.microsoft.helloforms`

Running Xamarin.Android project
`profile-android.ps1 -project HelloAndroid/HelloAndroid/HelloAndroid.csproj -package com.microsoft.helloandroid -configuration Release`

Running Flutter project
`profile-android.ps1 -package com.microsoft.helloflutter -project helloflutter` 

Current results 

|  Platform | Samsung SM-G950F  | Google Pixel 2  |
|   :---    |   :-:|---|
|  Flutter | 470.8 | 256.7  |
|  Xamarin Android | 547.5| 322.4  |
|  Xamarin Forms (4.8.0.1364) | 1196.4  |  777.2 |
