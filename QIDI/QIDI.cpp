#include <winsock2.h>
#include <Windows.h>
#include <mysql.h>
#include <iostream>
#include <cstdlib>
#include <sstream>
#include <cstring>
#include <string>


#pragma comment(lib,"libmysql.lib")

using namespace std;

int main()
{
	MYSQL mysql;
	mysql_init(&mysql);   //初始化MYSQL变量
	MYSQL_RES* result;
	MYSQL_ROW row;
	int num;        //用来存放结果集列数
	int i;
	char* query; //查询语句

	string DB_Server = "127.0.0.1";
	string DB_User = "root";
	string DB_Password = "";
	string DB_Database = "";
	int DB_Port = 3306;
	

	if (mysql_real_connect(&mysql, DB_Server.c_str(), DB_User.c_str(), DB_Password.c_str(), DB_Database.c_str(), DB_Port, NULL, 0))
	{
		cout << "\n\t-----MySQL已连接----" << endl;

		mysql_query(&mysql, "SET NAMES GB2312");	//库中含有中文，使用GB2312编码输出

		/*const string sql = "INSERT INTO test VALUES(4,'test4',1)";
		mysql_query(&mysql, sql.c_str());*/
	}
	else
	{
		cout << "\n\t-----Error MySQL无法连接到服务器----" << endl;
	}

	
		const char* a1 = "SELECT * FROM place_of_idc where Zone='";
		int gsd = 0;
		cout << "归属地：";
		cin >> gsd;
		const char* a2 = "';";
		ostringstream oss;
		oss << a1 << gsd << a2;
		string str = oss.str();

		if (!mysql_query(&mysql, str.c_str()))//若查询成功返回0，失败返回随机数
		{
			cout << "\n\t  ----查询成功----" << endl;
		}
		else
		{
			cout << "\n\t  ----查询失败----" << endl;
			Sleep(3000);	//Debug用
		}
	
	result = mysql_store_result(&mysql);    //将查询到的结果集储存到result中
	num = mysql_num_fields(result);        //将结果集列数存放到num中

	while ((row = mysql_fetch_row(result)))  //遇到最后一行，则中止循环
	{
		for (i = 0; i < num; i++)         //利用for循环，输出该行的每一列
		{
			cout << row[i] << "\t";    //row是MYSQL_ROW变量，可以当做数组使用，i为列数
		}
		cout << endl;
	}

	//const char* te = "INSERT INTO test VALUES ('9','test7','1')";
	//sprintf_s(query, te);
	//if (!mysql_query(&mysql,query))   //若写入成功返回0，失败返回随机数
	//{
	//	cout << "\n\t  ----写入成功----" << endl;
	//}

	/*cout << "\n\t  ----暂停3秒----" << endl;
	Sleep(3000);*/
	
	//if (!mysql_query(&mysql, "SELECT * FROM test"))   //若查询成功返回0，失败返回随机数
	//{
	//	cout << "\n\t  ----第二次查询成功----" << endl;
	//}

	//result = mysql_store_result(&mysql);    //将查询到的结果集储存到result中
	//num = mysql_num_fields(result);        //将结果集列数存放到num中

	//while ((row = mysql_fetch_row(result)))  //遇到最后一行，则中止循环
	//{
	//	for (i = 0; i < num; i++)         //利用for循环，输出该行的每一列
	//	{
	//		cout << row[i] << "\t";    //row是MYSQL_ROW变量，可以当做数组使用，i为列数
	//	}
	//	cout << endl;
	//}

	mysql_free_result(result);     //释放结果集所占用的内存
	mysql_close(&mysql);          //关闭与mysql的连接

	return 0;
}