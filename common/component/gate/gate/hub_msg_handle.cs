﻿using System;
using System.Collections;

namespace gate
{
	public class hub_msg_handle
	{
		public hub_msg_handle(hubmanager _hubmanager_, clientmanager _clientmanager_)
		{
			_hubmanager = _hubmanager_;
			_clientmanager = _clientmanager_;
		}

		public void reg_hub(string uuid)
		{
			hubproxy _hubproxy = _hubmanager.reg_hub(juggle.Imodule.current_ch, uuid);
			_hubproxy.reg_hub_sucess ();
		}

		public void forward_hub_call_group_client(ArrayList uuids, string module, string func, ArrayList argv)
		{
			foreach(String uuid in uuids)
			{
				clientproxy _clientproxy = _clientmanager.get_clientproxy(uuid);
				if (_clientproxy != null)
				{
					_clientproxy.call_client (module, func, argv);
				}
			}
		}

		public void forward_hub_call_global_client(string module, string func, ArrayList argv)
		{
			_clientmanager.for_each_client(
				(clientproxy _clientproxy) => {
					_clientproxy.call_client(module, func, argv);
				}
			);
		}

		private hubmanager _hubmanager;
		private clientmanager _clientmanager;
	}
}

