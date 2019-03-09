//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using LinqToDB;
using LinqToDB.DataProvider.SqlServer;
using LinqToDB.Extensions;
using LinqToDB.Mapping;

namespace Lab.EntityModel
{
	/// <summary>
	/// Database       : LabEmployee2
	/// Data Source    : (localdb)\mssqllocaldb
	/// Server Version : 13.00.4001
	/// </summary>
	public partial class LabEmployee2DB : LinqToDB.Data.DataConnection
	{
		public ITable<Employee> Employees  { get { return this.GetTable<Employee>(); } }
		public ITable<Identity> Identities { get { return this.GetTable<Identity>(); } }
		public ITable<Order>    Orders     { get { return this.GetTable<Order>(); } }

		public LabEmployee2DB()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public LabEmployee2DB(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();

		#region FreeTextTable

		public class FreeTextKey<T>
		{
			public T   Key;
			public int Rank;
		}

		private static MethodInfo _freeTextTableMethod1 = typeof(LabEmployee2DB).GetMethod("FreeTextTable", new Type[] { typeof(string), typeof(string) });

		[FreeTextTableExpression]
		public ITable<FreeTextKey<TKey>> FreeTextTable<TTable, TKey>(string field, string text)
		{
			return this.GetTable<FreeTextKey<TKey>>(
				this,
				_freeTextTableMethod1,
				field,
				text);
		}

		private static MethodInfo _freeTextTableMethod2 = 
			typeof(LabEmployee2DB).GetMethods()
				.Where(m => m.Name == "FreeTextTable" &&  m.IsGenericMethod && m.GetParameters().Length == 2)
				.Where(m => m.GetParameters()[0].ParameterType.IsGenericTypeEx() && m.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(Expression<>))
				.Where(m => m.GetParameters()[1].ParameterType == typeof(string))
				.Single();

		[FreeTextTableExpression]
		public ITable<FreeTextKey<TKey>> FreeTextTable<TTable, TKey>(Expression<Func<TTable,string>> fieldSelector, string text)
		{
			return this.GetTable<FreeTextKey<TKey>>(
				this,
				_freeTextTableMethod2,
				fieldSelector,
				text);
		}

		#endregion
	}

	[Table(Schema="dbo", Name="Employee")]
	public partial class Employee
	{
		[PrimaryKey, NotNull    ] public Guid   Id         { get; set; } // uniqueidentifier
		[Column,        Nullable] public string Name       { get; set; } // nvarchar(50)
		[Column,        Nullable] public int?   Age        { get; set; } // int
		[Identity               ] public long   SequenceId { get; set; } // bigint
		[Column,        Nullable] public string Remark     { get; set; } // nvarchar(50)

		#region Associations

		/// <summary>
		/// FK_Identity_Employee_Id_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="EmployeeId", CanBeNull=true, Relationship=Relationship.OneToOne, IsBackReference=true)]
		public Identity IdentityId { get; set; }

		/// <summary>
		/// FK_Order_Employee_id_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="EmployeeId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<Order> Orderids { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Identity")]
	public partial class Identity
	{
		[Column("Employee_Id"), PrimaryKey,  NotNull] public Guid   EmployeeId { get; set; } // uniqueidentifier
		[Column(),                           NotNull] public string Account    { get; set; } // nvarchar(50)
		[Column(),                           NotNull] public string Password   { get; set; } // nvarchar(50)
		[Column(),              Identity            ] public long   SequenceId { get; set; } // bigint
		[Column(),                 Nullable         ] public string Remark     { get; set; } // nvarchar(50)

		#region Associations

		/// <summary>
		/// FK_Identity_Employee_Id
		/// </summary>
		[Association(ThisKey="EmployeeId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.OneToOne, KeyName="FK_Identity_Employee_Id", BackReferenceName="IdentityId")]
		public Employee Employee { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Order")]
	public partial class Order
	{
		[Column(),              PrimaryKey,  NotNull] public Guid      Id         { get; set; } // uniqueidentifier
		[Column("Employee_Id"),    Nullable         ] public Guid?     EmployeeId { get; set; } // uniqueidentifier
		[Column(),                 Nullable         ] public DateTime? OrderTime  { get; set; } // datetime
		[Column(),                 Nullable         ] public string    Remark     { get; set; } // nvarchar(50)
		[Column(),              Identity            ] public long      SequenceId { get; set; } // bigint

		#region Associations

		/// <summary>
		/// FK_Order_Employee_id
		/// </summary>
		[Association(ThisKey="EmployeeId", OtherKey="Id", CanBeNull=true, Relationship=Relationship.ManyToOne, KeyName="FK_Order_Employee_id", BackReferenceName="Orderids")]
		public Employee Employee { get; set; }

		#endregion
	}

	public static partial class TableExtensions
	{
		public static Employee Find(this ITable<Employee> table, Guid Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static Identity Find(this ITable<Identity> table, Guid EmployeeId)
		{
			return table.FirstOrDefault(t =>
				t.EmployeeId == EmployeeId);
		}

		public static Order Find(this ITable<Order> table, Guid Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}
	}
}

#pragma warning restore 1591