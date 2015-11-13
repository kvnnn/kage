using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
	id 					: integer
	stage_id : integer
*/

public class User
{
#region Static
	private const int USER_ID = 1;
	private static User user;
	public static User GetUser()
	{
		if (user != null) {return user;}

		string query = string.Format("select * from user where id = {0}", USER_ID);
		DataTable table = Database.instance.Execute(query);
		user = new User(table.Rows[0]);
		return user;
	}
#endregion

#region UserData
	public DataRow rawData {get; private set;}
	public int id {get; private set;}
	public int stageId {get; private set;}

	public User(DataRow rawData)
	{
		this.rawData = rawData;

		id = (int)rawData["id"];
		stageId = (int)rawData["stage_id"];
	}
#endregion
}
