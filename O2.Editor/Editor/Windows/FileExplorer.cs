using ImGuiNET;
using Runtime.Editor.lib;

public class FileExplorer : EditorWindow {
    private string currentDirectory = "C:/"; // Başlangıç dizini
    private string selectedFile = string.Empty; // Seçilen dosya
    private string[] directories;
    private string[] files;


    private void LoadDirectoryContents() {
        try
        {
            // Klasörleri ve dosyaları oku
            directories = Directory.GetDirectories(currentDirectory).Select(d => Path.GetFileName(d)).ToArray();
            files = Directory.GetFiles(currentDirectory).Select(f => Path.GetFileName(f)).ToArray();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading directory: {ex.Message}");
            directories = Array.Empty<string>();
            files = Array.Empty<string>();
        }
    }


    public override void OnOpen() {
        
    }

    protected override void Draw() {
        float panelHeight = 200.0f; 

        ImGui.SetNextWindowPos(new System.Numerics.Vector2(0, ImGui.GetIO().DisplaySize.Y - panelHeight),
            ImGuiCond.Always);
        ImGui.SetNextWindowSize(new System.Numerics.Vector2(ImGui.GetIO().DisplaySize.X, panelHeight),
            ImGuiCond.Always);
        if (ImGui.Begin("File Explorer",
                ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar))
        {
            // Panelin başlığını göster
            ImGui.Text($"Current Directory: {currentDirectory}");

            // Dizini ve dosyaları oku
            LoadDirectoryContents();

            // Klasörleri listele
            if (directories.Length > 0)
            {
                ImGui.Text("Directories:");
                foreach (var dir in directories)
                {
                    if (ImGui.Selectable(dir, false))
                    {
                        // Klasöre tıklandığında dizini değiştir
                        currentDirectory = Path.Combine(currentDirectory, dir);
                        selectedFile = string.Empty;
                    }
                }
            }

            // Dosyaları listele
            if (files.Length > 0)
            {
                ImGui.Text("Files:");
                foreach (var file in files)
                {
                    if (ImGui.Selectable(file, false))
                    {
                        // Dosyaya tıklandığında seçilen dosyayı güncelle
                        selectedFile = Path.Combine(currentDirectory, file);
                    }
                }
            }

            // Seçilen dosyayı göster
            if (!string.IsNullOrEmpty(selectedFile))
            {
                ImGui.Text($"Selected File: {selectedFile}");
            }

            ImGui.End();
        }
    }
}