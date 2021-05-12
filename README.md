# HelloWorld
 Testing Flutter/ Xamarin Android / Xamarin Forms startup time


Running Xamarin.Forms project
`profile-android.ps1 -project HelloForms/HelloForms.Android/HelloForms.Android.csproj -configuration Release -extra /p:USE_XAMLC=true -xamarinformsversion 4.8.0.1364 -package com.microsoft.helloforms`

Running Xamarin.Android project
`profile-android.ps1 -project HelloAndroid/HelloAndroid/HelloAndroid.csproj -package com.microsoft.helloandroid -configuration Release`

Running Xamarin.Android project with Microsoft.Extensions.Hosting
`profile-android.ps1 -project HelloAndroid/HelloAndroid/HelloAndroid.csproj -package com.microsoft.helloandroid -configuration Release -extra /p:USE_BUILDER=true`

Running Flutter project
`profile-android.ps1 -package com.microsoft.helloflutter -project helloflutter` 

Running .NET6 Android project
`profile-android.ps1 -dotnet dotnet -project HelloAndroidNet6\HelloAndroidNet6.csproj -package com.microsoft.HelloAndroidNet6 -configuration Release`

Current results 

|  Platform | Samsung SM-G950F  | Google Pixel 2  | 
|   :---    |   :-:|---|
|  Flutter | 470.8 ms | 252.4 ms |
|  .NET6 Android | | 344.4 ms |
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


|  Flutter | Xamarin.Android  | Xamarin.Forms  | 
|   :---:  |   :---------:    |   :--------:   |
| ![Screenshot_20201022-153233](https://user-images.githubusercontent.com/1235097/96887216-49b48680-147c-11eb-9230-1d0040cea50f.png)   | ![Screenshot_20201022-152758](https://user-images.githubusercontent.com/1235097/96887259-53d68500-147c-11eb-9ce8-d8fe410a06ef.png) | ![Screenshot_20201022-152956](https://user-images.githubusercontent.com/1235097/96887308-60f37400-147c-11eb-9f98-0aedd29e9c80.png)
 |
