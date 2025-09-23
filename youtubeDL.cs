using System.Diagnostics;
namespace YoutubeDLCS;

public class youtubeDL
{
    private readonly string _path;
    

    public youtubeDL(string path)
    {
        _path = path;
        if (!File.Exists(_path))
            throw new FileNotFoundException("youtube-dl executable not found at the specified path.", _path);
        
        if (string.IsNullOrWhiteSpace(_path))
            throw new ArgumentException("Path cannot be null or empty.", nameof(path));
    }

    public int Download(string url, string outputDirectory, string? format = null)
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentException("URL cannot be null or empty.", nameof(url));
        
        if (string.IsNullOrWhiteSpace(outputDirectory))
            throw new ArgumentException("Output directory cannot be null or empty.", nameof(outputDirectory));
        
        if (!Directory.Exists(outputDirectory))
            Directory.CreateDirectory(outputDirectory);

        var formatArg = string.IsNullOrWhiteSpace(format) ? "" : $"-f {format} ";
        var processInfo = new ProcessStartInfo
        {
            FileName = _path,
            Arguments = $"{formatArg}-o \"{Path.Combine(outputDirectory, "%(title)s.%(ext)s")}\" {url}",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process { StartInfo = processInfo };
        process.Start();
        process.WaitForExit();

        return process.ExitCode;
    }
    public int DownloadPlaylist(string playlistUrl, string outputDirectory, string? format = null)
    {
        if (string.IsNullOrWhiteSpace(playlistUrl))
            throw new ArgumentException("Playlist URL cannot be null or empty.", nameof(playlistUrl));
        
        if (string.IsNullOrWhiteSpace(outputDirectory))
            throw new ArgumentException("Output directory cannot be null or empty.", nameof(outputDirectory));
        
        if (!Directory.Exists(outputDirectory))
            Directory.CreateDirectory(outputDirectory);

        var formatArg = string.IsNullOrWhiteSpace(format) ? "" : $"-f {format} ";
        var processInfo = new ProcessStartInfo
        {
            FileName = _path,
            Arguments = $"{formatArg}-o \"{Path.Combine(outputDirectory, "%(playlist)s/%(title)s.%(ext)s")}\" {playlistUrl}",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process { StartInfo = processInfo };
        process.Start();
        process.WaitForExit();

        return process.ExitCode;
    }
}
