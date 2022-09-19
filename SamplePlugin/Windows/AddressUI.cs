using System;
using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace SamplePlugin.Windows;

public class AddressUI : Window, IDisposable
{
    private Plugin Plugin;

    public  AddressUI(Plugin plugin) : base(
        "Address", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        this.SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(375, 330),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };

        this.Plugin = plugin;
    }
    public void Dispose() { }

    //draw the window that will store the address information
    public override void Draw()
    {
        ImGui.Text($"The random config bool is {this.Plugin.Configuration.SomePropertyToBeSavedAndWithADefault}");

        if (ImGui.Button("Show Settings"))
        {
            this.Plugin.DrawConfigUI();
        }
        if (ImGui.Button("Save"))
        {
        }

        ImGui.Spacing();
        var test = "Test";
        ImGui.Text("label");
        ImGui.SameLine();
        ImGui.InputText("Label", ref test, 255);
        ImGui.BeginTable("AddressLookup", 2 );
        /*for (int row = 0; row < 4; row++)
        {
            ImGui.TableNextRow();
            ImGui.TableNextColumn();
            ImGui.Text($"Row {row}");
            ImGui.TableNextColumn();
            ImGui.Text("Some contents");
            ImGui.TableNextColumn();
            ImGui.InputText("##Label", ref test, 255);
        }*/
        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TableSetupColumn("#Col", ImGuiTableColumnFlags.WidthFixed );
        ImGui.Text($"Name:");
        ImGui.TableNextColumn();
        ImGui.InputText("##Name", ref test, 255);
        ImGui.EndTable();

    }
}
