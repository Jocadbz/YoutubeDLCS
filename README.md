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

// Download with default format
int exitCode = ytdl.Download("https://www.youtube.com/watch?v=example", "/path/to/output");

// Download with specific format (e.g., mp4)
int exitCodeMp4 = ytdl.Download("https://www.youtube.com/watch?v=example", "/path/to/output", "mp4");

// Download playlist with default format
int playlistExitCode = ytdl.DownloadPlaylist("https://www.youtube.com/playlist?list=example", "/path/to/output");

// Download playlist with specific format
int playlistExitCodeMp4 = ytdl.DownloadPlaylist("https://www.youtube.com/playlist?list=example", "/path/to/output", "mp4");

if (exitCode == 0)
	Console.WriteLine("Download successful!");
else
	Console.WriteLine($"Download failed with exit code {exitCode}");
```

### API

#### `youtubeDL`
- **Constructor:** `youtubeDL(string path)`
	- Path to the youtube-dl executable.
- **Method:** `int Download(string url, string outputDirectory, string? format = null)`
	- Downloads the video at `url` to the specified directory.
	- Optional `format` parameter to select video format (e.g., "mp4", "best").
	- Returns the process exit code.
- **Method:** `int DownloadPlaylist(string playlistUrl, string outputDirectory, string? format = null)`
	- Downloads all videos in the playlist to the specified directory.
	- Optional `format` parameter to select video format.
	- Returns the process exit code.

### License
MIT
