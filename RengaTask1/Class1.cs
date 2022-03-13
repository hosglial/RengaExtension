using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RengaTask1
{
    class CountSelectionButton
    {
        private Renga.IUI m_ui;
        private Renga.ActionEventSource m_actionEvents;
        private Renga.Application app;

        internal Renga.IAction Action { get; }

        public CountSelectionButton(Renga.IUI ui, string tooltip, Renga.Application app)
        {
            m_ui = ui;            
            Action = ui.CreateAction();
            Action.ToolTip = tooltip;
            m_actionEvents = new Renga.ActionEventSource(Action);
            m_actionEvents.Triggered += onActionEventsTriggered;
        }

        protected virtual void onActionEventsTriggered(object sender, EventArgs e)
        {          
            m_ui.ShowMessageBox(Renga.MessageIcon.MessageIcon_Info,
                                "Count select",
                                "SampleText");
        }

        public void AddToPanel(Renga.IUIPanelExtension panel)
        {
            panel.AddToolButton(Action);
        }
    }
    public class SamplePlugin : Renga.IPlugin
    {
        List<CountSelectionButton> m_buttons = new List<CountSelectionButton>();

        public bool Initialize(string pluginFolder)
        {
            var app = new Renga.Application();
            var ui = app.UI;

            List<int> selected = new List<int>();




            var btn1 = new CountSelectionButton(ui, "Count selection", app);
            var btn2 = new CountSelectionButton(ui, "Sample button1", app);
            var btn3 = new CountSelectionButton(ui, "Sample button2", app);

            m_buttons.Add(btn1);
            m_buttons.Add(btn2);
            m_buttons.Add(btn3);

            var panelExtension = ui.CreateUIPanelExtension();

            foreach (var button in m_buttons)
                button.AddToPanel(panelExtension);

            ui.AddExtensionToPrimaryPanel(panelExtension);

            return true;
        }

        public void Stop()
        {
        }
    }
}
