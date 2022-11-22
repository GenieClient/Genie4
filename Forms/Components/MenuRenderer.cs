using System;
using System.Drawing;
using System.Windows.Forms;


namespace GenieClient.Forms.Components
{
    internal class MenuRenderer : ToolStripProfessionalRenderer
    {
        private Genie.Globals.Presets Presets;
        public MenuRenderer(Genie.Globals.Presets PresetList) : base(new MenuColors(PresetList)) 
        { 
            Presets = PresetList;
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderMenuItemBackground(e);
            e.Item.ForeColor = Presets["ui.menu"].FgColor;
            e.Item.BackColor = Presets["ui.menu"].BgColor;
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBackground(e);
            e.ToolStrip.ForeColor = Presets["ui.menu"].FgColor;
            e.ToolStrip.BackColor = Presets["ui.menu"].BgColor;
        }
    }

    internal class MenuColors : ProfessionalColorTable
    {
        Genie.Globals.Presets Presets;
        public MenuColors(Genie.Globals.Presets PresetList)
        {
            Presets = PresetList;
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return Presets["ui.menu.highlight"].FgColor; }
        }

        public override Color MenuItemPressedGradientMiddle
        {
            get { return Color.Transparent; }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.Transparent; }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.Transparent; }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return Presets["ui.menu.highlight"].FgColor; }
        }

        public override Color CheckBackground 
        {
            get { return Presets["ui.menu.checked"].FgColor; }
        }
        public override Color CheckSelectedBackground 
        {
            get { return Presets["ui.menu.highlight"].FgColor; }
        }

        public override Color ImageMarginGradientBegin 
        {
            get { return Presets["ui.menu"].BgColor; }
        }

        public override Color ImageMarginGradientMiddle 
        {
            get { return Presets["ui.menu"].BgColor; }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return Presets["ui.menu"].BgColor; }
        }
    }
}
