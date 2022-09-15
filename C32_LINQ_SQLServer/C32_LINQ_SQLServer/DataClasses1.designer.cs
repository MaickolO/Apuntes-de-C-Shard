﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace C32_LINQ_SQLServer
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="GestionPedidos")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertEmpresa(Empresa instance);
    partial void UpdateEmpresa(Empresa instance);
    partial void DeleteEmpresa(Empresa instance);
    partial void InsertEmpleado(Empleado instance);
    partial void UpdateEmpleado(Empleado instance);
    partial void DeleteEmpleado(Empleado instance);
    partial void InsertCargo(Cargo instance);
    partial void UpdateCargo(Cargo instance);
    partial void DeleteCargo(Cargo instance);
    partial void InsertCargoEmpleado(CargoEmpleado instance);
    partial void UpdateCargoEmpleado(CargoEmpleado instance);
    partial void DeleteCargoEmpleado(CargoEmpleado instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::C32_LINQ_SQLServer.Properties.Settings.Default.GestionPedidosConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Empresa> Empresa
		{
			get
			{
				return this.GetTable<Empresa>();
			}
		}
		
		public System.Data.Linq.Table<Empleado> Empleado
		{
			get
			{
				return this.GetTable<Empleado>();
			}
		}
		
		public System.Data.Linq.Table<Cargo> Cargo
		{
			get
			{
				return this.GetTable<Cargo>();
			}
		}
		
		public System.Data.Linq.Table<CargoEmpleado> CargoEmpleado
		{
			get
			{
				return this.GetTable<CargoEmpleado>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Empresa")]
	public partial class Empresa : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _nombre;
		
		private EntitySet<Empleado> _Empleado;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnombreChanging(string value);
    partial void OnnombreChanged();
    #endregion
		
		public Empresa()
		{
			this._Empleado = new EntitySet<Empleado>(new Action<Empleado>(this.attach_Empleado), new Action<Empleado>(this.detach_Empleado));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="NVarChar(50)")]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this.OnnombreChanging(value);
					this.SendPropertyChanging();
					this._nombre = value;
					this.SendPropertyChanged("nombre");
					this.OnnombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Empresa_Empleado", Storage="_Empleado", ThisKey="id", OtherKey="idEmpresa")]
		public EntitySet<Empleado> Empleado
		{
			get
			{
				return this._Empleado;
			}
			set
			{
				this._Empleado.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Empleado(Empleado entity)
		{
			this.SendPropertyChanging();
			entity.Empresa = this;
		}
		
		private void detach_Empleado(Empleado entity)
		{
			this.SendPropertyChanging();
			entity.Empresa = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Empleado")]
	public partial class Empleado : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _nombre;
		
		private string _apellido;
		
		private int _idEmpresa;
		
		private EntitySet<CargoEmpleado> _CargoEmpleado;
		
		private EntityRef<Empresa> _Empresa;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnombreChanging(string value);
    partial void OnnombreChanged();
    partial void OnapellidoChanging(string value);
    partial void OnapellidoChanged();
    partial void OnidEmpresaChanging(int value);
    partial void OnidEmpresaChanged();
    #endregion
		
		public Empleado()
		{
			this._CargoEmpleado = new EntitySet<CargoEmpleado>(new Action<CargoEmpleado>(this.attach_CargoEmpleado), new Action<CargoEmpleado>(this.detach_CargoEmpleado));
			this._Empresa = default(EntityRef<Empresa>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this.OnnombreChanging(value);
					this.SendPropertyChanging();
					this._nombre = value;
					this.SendPropertyChanged("nombre");
					this.OnnombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_apellido", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string apellido
		{
			get
			{
				return this._apellido;
			}
			set
			{
				if ((this._apellido != value))
				{
					this.OnapellidoChanging(value);
					this.SendPropertyChanging();
					this._apellido = value;
					this.SendPropertyChanged("apellido");
					this.OnapellidoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idEmpresa", DbType="Int NOT NULL")]
		public int idEmpresa
		{
			get
			{
				return this._idEmpresa;
			}
			set
			{
				if ((this._idEmpresa != value))
				{
					if (this._Empresa.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidEmpresaChanging(value);
					this.SendPropertyChanging();
					this._idEmpresa = value;
					this.SendPropertyChanged("idEmpresa");
					this.OnidEmpresaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Empleado_CargoEmpleado", Storage="_CargoEmpleado", ThisKey="id", OtherKey="idEmpleado")]
		public EntitySet<CargoEmpleado> CargoEmpleado
		{
			get
			{
				return this._CargoEmpleado;
			}
			set
			{
				this._CargoEmpleado.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Empresa_Empleado", Storage="_Empresa", ThisKey="idEmpresa", OtherKey="id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Empresa Empresa
		{
			get
			{
				return this._Empresa.Entity;
			}
			set
			{
				Empresa previousValue = this._Empresa.Entity;
				if (((previousValue != value) 
							|| (this._Empresa.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Empresa.Entity = null;
						previousValue.Empleado.Remove(this);
					}
					this._Empresa.Entity = value;
					if ((value != null))
					{
						value.Empleado.Add(this);
						this._idEmpresa = value.id;
					}
					else
					{
						this._idEmpresa = default(int);
					}
					this.SendPropertyChanged("Empresa");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_CargoEmpleado(CargoEmpleado entity)
		{
			this.SendPropertyChanging();
			entity.Empleado = this;
		}
		
		private void detach_CargoEmpleado(CargoEmpleado entity)
		{
			this.SendPropertyChanging();
			entity.Empleado = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Cargo")]
	public partial class Cargo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _nombre;
		
		private EntitySet<CargoEmpleado> _CargoEmpleado;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnombreChanging(string value);
    partial void OnnombreChanged();
    #endregion
		
		public Cargo()
		{
			this._CargoEmpleado = new EntitySet<CargoEmpleado>(new Action<CargoEmpleado>(this.attach_CargoEmpleado), new Action<CargoEmpleado>(this.detach_CargoEmpleado));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this.OnnombreChanging(value);
					this.SendPropertyChanging();
					this._nombre = value;
					this.SendPropertyChanged("nombre");
					this.OnnombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Cargo_CargoEmpleado", Storage="_CargoEmpleado", ThisKey="id", OtherKey="idCargo")]
		public EntitySet<CargoEmpleado> CargoEmpleado
		{
			get
			{
				return this._CargoEmpleado;
			}
			set
			{
				this._CargoEmpleado.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_CargoEmpleado(CargoEmpleado entity)
		{
			this.SendPropertyChanging();
			entity.Cargo = this;
		}
		
		private void detach_CargoEmpleado(CargoEmpleado entity)
		{
			this.SendPropertyChanging();
			entity.Cargo = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CargoEmpleado")]
	public partial class CargoEmpleado : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _idCargo;
		
		private int _idEmpleado;
		
		private EntityRef<Cargo> _Cargo;
		
		private EntityRef<Empleado> _Empleado;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnidCargoChanging(int value);
    partial void OnidCargoChanged();
    partial void OnidEmpleadoChanging(int value);
    partial void OnidEmpleadoChanged();
    #endregion
		
		public CargoEmpleado()
		{
			this._Cargo = default(EntityRef<Cargo>);
			this._Empleado = default(EntityRef<Empleado>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idCargo", DbType="Int NOT NULL")]
		public int idCargo
		{
			get
			{
				return this._idCargo;
			}
			set
			{
				if ((this._idCargo != value))
				{
					if (this._Cargo.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidCargoChanging(value);
					this.SendPropertyChanging();
					this._idCargo = value;
					this.SendPropertyChanged("idCargo");
					this.OnidCargoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idEmpleado", DbType="Int NOT NULL")]
		public int idEmpleado
		{
			get
			{
				return this._idEmpleado;
			}
			set
			{
				if ((this._idEmpleado != value))
				{
					if (this._Empleado.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidEmpleadoChanging(value);
					this.SendPropertyChanging();
					this._idEmpleado = value;
					this.SendPropertyChanged("idEmpleado");
					this.OnidEmpleadoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Cargo_CargoEmpleado", Storage="_Cargo", ThisKey="idCargo", OtherKey="id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Cargo Cargo
		{
			get
			{
				return this._Cargo.Entity;
			}
			set
			{
				Cargo previousValue = this._Cargo.Entity;
				if (((previousValue != value) 
							|| (this._Cargo.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cargo.Entity = null;
						previousValue.CargoEmpleado.Remove(this);
					}
					this._Cargo.Entity = value;
					if ((value != null))
					{
						value.CargoEmpleado.Add(this);
						this._idCargo = value.id;
					}
					else
					{
						this._idCargo = default(int);
					}
					this.SendPropertyChanged("Cargo");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Empleado_CargoEmpleado", Storage="_Empleado", ThisKey="idEmpleado", OtherKey="id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Empleado Empleado
		{
			get
			{
				return this._Empleado.Entity;
			}
			set
			{
				Empleado previousValue = this._Empleado.Entity;
				if (((previousValue != value) 
							|| (this._Empleado.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Empleado.Entity = null;
						previousValue.CargoEmpleado.Remove(this);
					}
					this._Empleado.Entity = value;
					if ((value != null))
					{
						value.CargoEmpleado.Add(this);
						this._idEmpleado = value.id;
					}
					else
					{
						this._idEmpleado = default(int);
					}
					this.SendPropertyChanged("Empleado");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591