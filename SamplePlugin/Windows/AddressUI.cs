using System;
using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace SamplePlugin;

public class AddressUI : Window, IDisposable
{
    private Plugin Plugin;
    private Address Address;

    public  AddressUI(Plugin plugin) : base(
        "New Address", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        this.SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(375, 330),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };

        this.Plugin = plugin;
        this.Address = new Address();

    }
    public void Dispose() { }

    //draw the window that will store the address information
    public override void Draw()
    {
        var name = Address.Name;
        var desc = Address.Description;
        ImGui.Text("Name: ");
        ImGui.SameLine();
        ImGui.InputText("##Name", ref name,255);

        //int item = 1;
        //ImGui.Combo("##combo", ref item, "aaaa\0bbbb\0cccc\0dddd\0eeee\0\0");
        string[] districts = {"","Empyreum","Mist","Goblet","Shirogane","Lavender Beds"};
        var current_item = 1;
        var current_ward = 0;
        var current_plot = 0;

        //District Selection
        ImGui.Text("District");
        ImGui.SameLine();
        ImGui.Combo("##District", ref current_item, districts, districts.Length);
        ImGui.Text("Ward");
        ImGui.SameLine();
        ImGui.InputInt("##Ward", ref current_ward);
        //ImGui.SameLine();
        ImGui.Text("Plot");
        ImGui.SameLine();
        ImGui.InputInt("##Plot", ref current_plot);
        /*for (int n = 0; n < districts.Length; n++)
        {
            bool is_selected = (current_item == n); // You can store your selection however you want, outside or inside your objects
            if (ImGui.Selectable(districts[n], is_selected)){
                current_item = n;
            }
            if (is_selected)
            {
                ImGui.SetItemDefaultFocus();   // You may set the initial focus when opening the combo (scrolling + for keyboard navigation support)
            }

        }*/
        ImGui.Text("Description:");
        ImGui.InputTextMultiline("##Description", ref desc, 1024, new Vector2(ImGui.GetWindowWidth()-50, 160f));
        ImGui.Spacing();
        if (ImGui.Button("Save"))
        {
            this.Save();
        }

    }

    public void Save()
    {
    }
}
