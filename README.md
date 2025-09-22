## YoutubeDLCS

A simple C# wrapper for running youtube-dl commands via a class interface.

### Features
- Download videos from YouTube using youtube-dl
- Specify output directory and file naming
- Handles process execution and error checking

### Requirements
- [.NET 6.0 or later](https://dotnet.microsoft.com/download)
- [youtube-dl](https://youtube-dl.org/) executable

### Installation
1. Clone this repository:
	 ```fish
	 git clone https://github.com/yourusername/YoutubeDLCS.git
	 ```
2. Build the project:
	 ```fish
	 cd YoutubeDLCS
	 dotnet build
	 ```
3. Ensure `youtube-dl` is installed and note its path.

### Usage
Example usage in your C# project:
```csharp
using YoutubeDLCS;

var ytdl = new youtubeDL("/path/to/youtube-dl");
int exitCode = ytdl.Download("https://www.youtube.com/watch?v=example", "/path/to/output");
if (exitCode == 0)
		Console.WriteLine("Download successful!");
else
		Console.WriteLine($"Download failed with exit code {exitCode}");
```

### API
#### `youtubeDL`
- **Constructor:** `youtubeDL(string path)`
	- Path to the youtube-dl executable.
- **Method:** `int Download(string url, string outputDirectory)`
	- Downloads the video at `url` to the specified directory.
	- Returns the process exit code.

### License
MIT
