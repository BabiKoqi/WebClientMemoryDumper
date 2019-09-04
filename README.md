# WebClientMemoryDumper
Uses Harmony to intercept methods used by WebClient, xNet, etc. and log URLs

### Features

- Uses Harmony to hook `CreateThis` method from `System.Uri` and logs all URLs catched there
- Automatically spoofs the return value of `Assembly.GetEntryAssembly()`, so the target assembly won't even know it is being run externally :p

### Usage
Drag and drop a .NET assembly on WebClientMemoryDumper.exe and watch it collect all the URLs

### (maybe) Upcoming features

- Better logging
- Code cleanup
