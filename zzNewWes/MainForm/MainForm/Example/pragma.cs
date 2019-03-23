﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wes;

class Program
{
    private static wes.SqLiteHelper sql;
    static void dllMain(string[] args)
    {
        sql = new SqLiteHelper();
        sql.SqliteOpen("");

        //创建名为table1的数据表
        sql.CreateTable("table1", new string[] { "ID", "Name", "Age", "Email" }, new string[] { "INTEGER", "TEXT", "INTEGER", "TEXT" });
        //插入两条数据
        sql.InsertValues("table1", new string[] { "1", "张三", "22", "Zhang@163.com" });
        sql.InsertValues("table1", new string[] { "2", "李四", "25", "Li4@163.com" });

        //更新数据，将Name="张三"的记录中的Name改为"Zhang3"
        sql.UpdateValues("table1", new string[] { "Name" }, new string[] { "ZhangSan" }, "Name", "Zhang3");

        //删除Name="张三"且Age=26的记录,DeleteValuesOR方法类似
        sql.DeleteValuesAND("table1", new string[] { "Name", "Age" }, new string[] { "张三", "22" }, new string[] { "=", "=" });


        //读取整张表
        SQLiteDataReader reader = sql.ReadFullTable("table1");
        while (reader.Read())
        {
            //读取ID
            Log("" + reader.GetInt32(reader.GetOrdinal("ID")));
            //读取Name
            Log("" + reader.GetString(reader.GetOrdinal("Name")));
            //读取Age
            Log("" + reader.GetInt32(reader.GetOrdinal("Age")));
            //读取Email
            Log(reader.GetString(reader.GetOrdinal("Email")));
        }

        while (true)
        {
            Console.ReadLine();
        }
    }

    static void Log(string s)
    {
        Console.WriteLine("" + s);
    }
}