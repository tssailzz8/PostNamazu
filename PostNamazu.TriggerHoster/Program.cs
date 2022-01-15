﻿using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriggernometryProxy;

namespace PostNamazu.TriggerHoster
{
    public class Program
    {
        public Action<string, string> PostNamazuDelegate = null;
        public ProxyPlugin _triggPlugin;

        public List<int> TriggCallbackId = new List<int>();

        public Program(IActPluginV1 plugin)
        {
            _triggPlugin= (ProxyPlugin)plugin;
        }
        public void Init(string[] commands)
        {
            foreach (string command in commands)
                TriggCallbackId.Add(_triggPlugin.RegisterNamedCallback(command, delegate (object _, string payload) { PostNamazuDelegate(command, payload); }, null));
        }
        public void ClearAction()
        {
            foreach (int id in TriggCallbackId) 
                _triggPlugin.UnregisterNamedCallback(id);
            TriggCallbackId.Clear();
        }
    }
}
