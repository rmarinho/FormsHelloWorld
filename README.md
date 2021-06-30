# HelloWorld
 Testing Flutter/ Xamarin Android / Xamarin Forms startup time


Running Xamarin.Forms project
`.\eng\scripts\profile-android.ps1 -project src/HelloForms/HelloForms.Android/HelloForms.Android.csproj -configuration Release -extra /p:USE_XAMLC=true -xamarinformsversion 4.8.0.1364 -package com.microsoft.helloforms`

Running Xamarin.Android project
`.\eng\scripts\profile-android.ps1 -project src/HelloAndroid/HelloAndroid.csproj -package com.microsoft.helloandroid -configuration Release`

Running Xamarin.Android project with Microsoft.Extensions.Hosting
`.\eng\scripts\profile-android.ps1 -project HelloAndroid/HelloAndroid/HelloAndroid.csproj -package com.microsoft.helloandroid -configuration Release -extra /p:USE_BUILDER=true`

Running Flutter project
`.\eng\scripts\profile-android.ps1 -package com.microsoft.helloflutter -project src/helloflutter` 

Running .NET6 Android project
`.\eng\scripts\profile-android.ps1 -dotnet dotnet -project src\HelloAndroidNet6\HelloAndroidNet6.csproj -package com.microsoft.HelloAndroidNet6 -configuration Release`

Running .NET6 MAUI project
`.\eng\scripts\profile-android.ps1 -dotnet dotnet -project src\HelloMaui\HelloMaui\HelloMaui.csproj -package com.microsoft.HelloMaui -target Run -configuration Release`

Current results 

|  Platform | Samsung SM-G950F  | Google Pixel 2  | 
|   :---    |   :-:|---|
|  Flutter | 470.8 ms | 252.4 ms |
|  Xamarin Android | 547.5 ms | 322.4 ms |
|  Xamarin Android AOT | 547.5 ms | 290.2 ms  |
|  Xamarin Android AOT (Custom profile) | 547.5 ms | 269.9 ms  |
|  Xamarin Android AOT with Hosting (Custom profile) |  | 547.7 ms  |
|  Xamarin Forms (4.8.0.1364) | 1196.4 ms |  947.8 ms |
|  Xamarin Forms (4.8.0.1364) XAMLC | 1196.4 ms |  777.2 ms |
|  Xamarin Forms (4.8.0.1364) AOT | * |  518.1 ms |
|  Xamarin Forms (4.8.0.1364) AOT (Custom profile)| * |  492 ms |
|  Xamarin Forms (4.8.0.1364) AOT XAMLC | * | 468.4 ms |
|  Xamarin Forms (4.8.0.1364) AOT XAMLC (Custom profile) | *  | 452 ms |
|  Xamarin Forms (5.0.0.2012) | *  | 1060 ms |
|  Xamarin Forms (5.0.0.2012) XAMLC | *  | 886 ms |
|  Xamarin Forms (5.0.0.2012) AOT XAMLC | *  | 470 ms |
|  Xamarin Forms (5.0.0.2012) AOT XAMLC (Custom profile) | *  | 455 ms |
|  .NET6 Android (Preview3) | | 344.4 ms |
|  .NET6 Android (Preview4) | | 339.4 ms |
|  .NET6 Android (Preview5) | | 378.1 ms |
|  .NET6 MAUI App (6.0.0-Preview.4.634) XAMLC | | 1091.2 ms |
|  .NET6 MAUI App (6.0.0-Preview.5.798) XAMLC | | 1232.3 ms |


|  Flutter | Xamarin.Android  | Xamarin.Forms  |  MAUI |
|   :---:  |   :---------:    |   :--------:   | :-----:   |
| ![Screenshot_20201022-153233](https://user-images.githubusercontent.com/1235097/96887216-49b48680-147c-11eb-9230-1d0040cea50f.png)   | ![Screenshot_20201022-152758](https://user-images.githubusercontent.com/1235097/96887259-53d68500-147c-11eb-9ce8-d8fe410a06ef.png) | ![Screenshot_20201022-152956](https://user-images.githubusercontent.com/1235097/96887308-60f37400-147c-11eb-9f98-0aedd29e9c80.png) | ![Screenshot_1622661946](https://user-images.githubusercontent.com/1235097/120541352-afd59480-c3e1-11eb-94bb-f4cdf4c8b376.png) |
