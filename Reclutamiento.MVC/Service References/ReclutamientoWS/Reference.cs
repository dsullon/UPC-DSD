﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Reclutamiento.MVC.ReclutamientoWS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Rubro", Namespace="http://schemas.datacontract.org/2004/07/SOAPServices.Dominio")]
    [System.SerializableAttribute()]
    public partial class Rubro : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OperationStatus", Namespace="http://schemas.datacontract.org/2004/07/SOAPServices.Dominio")]
    [System.SerializableAttribute()]
    public partial class OperationStatus : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] MessagesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool SuccessField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Messages {
            get {
                return this.MessagesField;
            }
            set {
                if ((object.ReferenceEquals(this.MessagesField, value) != true)) {
                    this.MessagesField = value;
                    this.RaisePropertyChanged("Messages");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Success {
            get {
                return this.SuccessField;
            }
            set {
                if ((this.SuccessField.Equals(value) != true)) {
                    this.SuccessField = value;
                    this.RaisePropertyChanged("Success");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Anuncio", Namespace="http://schemas.datacontract.org/2004/07/SOAPServices.Dominio")]
    [System.SerializableAttribute()]
    public partial class Anuncio : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TituloField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Titulo {
            get {
                return this.TituloField;
            }
            set {
                if ((object.ReferenceEquals(this.TituloField, value) != true)) {
                    this.TituloField = value;
                    this.RaisePropertyChanged("Titulo");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Aptitud", Namespace="http://schemas.datacontract.org/2004/07/SOAPServices.Dominio")]
    [System.SerializableAttribute()]
    public partial class Aptitud : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Aptitud_Anuncio", Namespace="http://schemas.datacontract.org/2004/07/SOAPServices.Dominio")]
    [System.SerializableAttribute()]
    public partial class Aptitud_Anuncio : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdAnuncioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdAptitudField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdAnuncio {
            get {
                return this.IdAnuncioField;
            }
            set {
                if ((this.IdAnuncioField.Equals(value) != true)) {
                    this.IdAnuncioField = value;
                    this.RaisePropertyChanged("IdAnuncio");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdAptitud {
            get {
                return this.IdAptitudField;
            }
            set {
                if ((this.IdAptitudField.Equals(value) != true)) {
                    this.IdAptitudField = value;
                    this.RaisePropertyChanged("IdAptitud");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReclutamientoWS.IReclutamientoService")]
    public interface IReclutamientoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/CrearRubro", ReplyAction="http://tempuri.org/IReclutamientoService/CrearRubroResponse")]
        Reclutamiento.MVC.ReclutamientoWS.Rubro CrearRubro(string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/CrearRubro", ReplyAction="http://tempuri.org/IReclutamientoService/CrearRubroResponse")]
        System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Rubro> CrearRubroAsync(string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ObtenerRubro", ReplyAction="http://tempuri.org/IReclutamientoService/ObtenerRubroResponse")]
        Reclutamiento.MVC.ReclutamientoWS.Rubro ObtenerRubro(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ObtenerRubro", ReplyAction="http://tempuri.org/IReclutamientoService/ObtenerRubroResponse")]
        System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Rubro> ObtenerRubroAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ModificarRubro", ReplyAction="http://tempuri.org/IReclutamientoService/ModificarRubroResponse")]
        Reclutamiento.MVC.ReclutamientoWS.Rubro ModificarRubro(int id, string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ModificarRubro", ReplyAction="http://tempuri.org/IReclutamientoService/ModificarRubroResponse")]
        System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Rubro> ModificarRubroAsync(int id, string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/EliminarRubro", ReplyAction="http://tempuri.org/IReclutamientoService/EliminarRubroResponse")]
        void EliminarRubro(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/EliminarRubro", ReplyAction="http://tempuri.org/IReclutamientoService/EliminarRubroResponse")]
        System.Threading.Tasks.Task EliminarRubroAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ListarRubros", ReplyAction="http://tempuri.org/IReclutamientoService/ListarRubrosResponse")]
        Reclutamiento.MVC.ReclutamientoWS.Rubro[] ListarRubros();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ListarRubros", ReplyAction="http://tempuri.org/IReclutamientoService/ListarRubrosResponse")]
        System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Rubro[]> ListarRubrosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/CrearAnuncio", ReplyAction="http://tempuri.org/IReclutamientoService/CrearAnuncioResponse")]
        Reclutamiento.MVC.ReclutamientoWS.OperationStatus CrearAnuncio(string titulo, string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/CrearAnuncio", ReplyAction="http://tempuri.org/IReclutamientoService/CrearAnuncioResponse")]
        System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.OperationStatus> CrearAnuncioAsync(string titulo, string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ObtenerAnuncio", ReplyAction="http://tempuri.org/IReclutamientoService/ObtenerAnuncioResponse")]
        Reclutamiento.MVC.ReclutamientoWS.Anuncio ObtenerAnuncio(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ObtenerAnuncio", ReplyAction="http://tempuri.org/IReclutamientoService/ObtenerAnuncioResponse")]
        System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Anuncio> ObtenerAnuncioAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ModificarAnuncio", ReplyAction="http://tempuri.org/IReclutamientoService/ModificarAnuncioResponse")]
        Reclutamiento.MVC.ReclutamientoWS.Anuncio ModificarAnuncio(int id, string titulo, string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ModificarAnuncio", ReplyAction="http://tempuri.org/IReclutamientoService/ModificarAnuncioResponse")]
        System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Anuncio> ModificarAnuncioAsync(int id, string titulo, string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/EliminarAnuncio", ReplyAction="http://tempuri.org/IReclutamientoService/EliminarAnuncioResponse")]
        void EliminarAnuncio(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/EliminarAnuncio", ReplyAction="http://tempuri.org/IReclutamientoService/EliminarAnuncioResponse")]
        System.Threading.Tasks.Task EliminarAnuncioAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ListarAnuncios", ReplyAction="http://tempuri.org/IReclutamientoService/ListarAnunciosResponse")]
        Reclutamiento.MVC.ReclutamientoWS.Anuncio[] ListarAnuncios();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ListarAnuncios", ReplyAction="http://tempuri.org/IReclutamientoService/ListarAnunciosResponse")]
        System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Anuncio[]> ListarAnunciosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/CrearAptitud", ReplyAction="http://tempuri.org/IReclutamientoService/CrearAptitudResponse")]
        Reclutamiento.MVC.ReclutamientoWS.Aptitud CrearAptitud(string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/CrearAptitud", ReplyAction="http://tempuri.org/IReclutamientoService/CrearAptitudResponse")]
        System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Aptitud> CrearAptitudAsync(string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ObtenerAptitud", ReplyAction="http://tempuri.org/IReclutamientoService/ObtenerAptitudResponse")]
        Reclutamiento.MVC.ReclutamientoWS.Aptitud ObtenerAptitud(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ObtenerAptitud", ReplyAction="http://tempuri.org/IReclutamientoService/ObtenerAptitudResponse")]
        System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Aptitud> ObtenerAptitudAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ModificarAptitud", ReplyAction="http://tempuri.org/IReclutamientoService/ModificarAptitudResponse")]
        Reclutamiento.MVC.ReclutamientoWS.Aptitud ModificarAptitud(int id, string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ModificarAptitud", ReplyAction="http://tempuri.org/IReclutamientoService/ModificarAptitudResponse")]
        System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Aptitud> ModificarAptitudAsync(int id, string descripcion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/EliminarAptitud", ReplyAction="http://tempuri.org/IReclutamientoService/EliminarAptitudResponse")]
        void EliminarAptitud(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/EliminarAptitud", ReplyAction="http://tempuri.org/IReclutamientoService/EliminarAptitudResponse")]
        System.Threading.Tasks.Task EliminarAptitudAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ListarAptitudes", ReplyAction="http://tempuri.org/IReclutamientoService/ListarAptitudesResponse")]
        Reclutamiento.MVC.ReclutamientoWS.Aptitud[] ListarAptitudes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ListarAptitudes", ReplyAction="http://tempuri.org/IReclutamientoService/ListarAptitudesResponse")]
        System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Aptitud[]> ListarAptitudesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/CrearAptitud_Anuncio", ReplyAction="http://tempuri.org/IReclutamientoService/CrearAptitud_AnuncioResponse")]
        Reclutamiento.MVC.ReclutamientoWS.Aptitud_Anuncio CrearAptitud_Anuncio(int idAnuncio, int idAptitud);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/CrearAptitud_Anuncio", ReplyAction="http://tempuri.org/IReclutamientoService/CrearAptitud_AnuncioResponse")]
        System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Aptitud_Anuncio> CrearAptitud_AnuncioAsync(int idAnuncio, int idAptitud);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ObtenerAptitud_Anuncio", ReplyAction="http://tempuri.org/IReclutamientoService/ObtenerAptitud_AnuncioResponse")]
        Reclutamiento.MVC.ReclutamientoWS.Aptitud_Anuncio ObtenerAptitud_Anuncio(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ObtenerAptitud_Anuncio", ReplyAction="http://tempuri.org/IReclutamientoService/ObtenerAptitud_AnuncioResponse")]
        System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Aptitud_Anuncio> ObtenerAptitud_AnuncioAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ModificarAptitud_Anuncio", ReplyAction="http://tempuri.org/IReclutamientoService/ModificarAptitud_AnuncioResponse")]
        Reclutamiento.MVC.ReclutamientoWS.Aptitud_Anuncio ModificarAptitud_Anuncio(int idAnuncio, int idAptitud);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ModificarAptitud_Anuncio", ReplyAction="http://tempuri.org/IReclutamientoService/ModificarAptitud_AnuncioResponse")]
        System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Aptitud_Anuncio> ModificarAptitud_AnuncioAsync(int idAnuncio, int idAptitud);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/EliminarAptitud_Anuncio", ReplyAction="http://tempuri.org/IReclutamientoService/EliminarAptitud_AnuncioResponse")]
        void EliminarAptitud_Anuncio(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/EliminarAptitud_Anuncio", ReplyAction="http://tempuri.org/IReclutamientoService/EliminarAptitud_AnuncioResponse")]
        System.Threading.Tasks.Task EliminarAptitud_AnuncioAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ListarAptitudesPorAnuncio", ReplyAction="http://tempuri.org/IReclutamientoService/ListarAptitudesPorAnuncioResponse")]
        Reclutamiento.MVC.ReclutamientoWS.Aptitud_Anuncio[] ListarAptitudesPorAnuncio();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReclutamientoService/ListarAptitudesPorAnuncio", ReplyAction="http://tempuri.org/IReclutamientoService/ListarAptitudesPorAnuncioResponse")]
        System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Aptitud_Anuncio[]> ListarAptitudesPorAnuncioAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReclutamientoServiceChannel : Reclutamiento.MVC.ReclutamientoWS.IReclutamientoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReclutamientoServiceClient : System.ServiceModel.ClientBase<Reclutamiento.MVC.ReclutamientoWS.IReclutamientoService>, Reclutamiento.MVC.ReclutamientoWS.IReclutamientoService {
        
        public ReclutamientoServiceClient() {
        }
        
        public ReclutamientoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReclutamientoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReclutamientoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReclutamientoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Reclutamiento.MVC.ReclutamientoWS.Rubro CrearRubro(string descripcion) {
            return base.Channel.CrearRubro(descripcion);
        }
        
        public System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Rubro> CrearRubroAsync(string descripcion) {
            return base.Channel.CrearRubroAsync(descripcion);
        }
        
        public Reclutamiento.MVC.ReclutamientoWS.Rubro ObtenerRubro(int id) {
            return base.Channel.ObtenerRubro(id);
        }
        
        public System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Rubro> ObtenerRubroAsync(int id) {
            return base.Channel.ObtenerRubroAsync(id);
        }
        
        public Reclutamiento.MVC.ReclutamientoWS.Rubro ModificarRubro(int id, string descripcion) {
            return base.Channel.ModificarRubro(id, descripcion);
        }
        
        public System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Rubro> ModificarRubroAsync(int id, string descripcion) {
            return base.Channel.ModificarRubroAsync(id, descripcion);
        }
        
        public void EliminarRubro(int id) {
            base.Channel.EliminarRubro(id);
        }
        
        public System.Threading.Tasks.Task EliminarRubroAsync(int id) {
            return base.Channel.EliminarRubroAsync(id);
        }
        
        public Reclutamiento.MVC.ReclutamientoWS.Rubro[] ListarRubros() {
            return base.Channel.ListarRubros();
        }
        
        public System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Rubro[]> ListarRubrosAsync() {
            return base.Channel.ListarRubrosAsync();
        }
        
        public Reclutamiento.MVC.ReclutamientoWS.OperationStatus CrearAnuncio(string titulo, string descripcion) {
            return base.Channel.CrearAnuncio(titulo, descripcion);
        }
        
        public System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.OperationStatus> CrearAnuncioAsync(string titulo, string descripcion) {
            return base.Channel.CrearAnuncioAsync(titulo, descripcion);
        }
        
        public Reclutamiento.MVC.ReclutamientoWS.Anuncio ObtenerAnuncio(int id) {
            return base.Channel.ObtenerAnuncio(id);
        }
        
        public System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Anuncio> ObtenerAnuncioAsync(int id) {
            return base.Channel.ObtenerAnuncioAsync(id);
        }
        
        public Reclutamiento.MVC.ReclutamientoWS.Anuncio ModificarAnuncio(int id, string titulo, string descripcion) {
            return base.Channel.ModificarAnuncio(id, titulo, descripcion);
        }
        
        public System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Anuncio> ModificarAnuncioAsync(int id, string titulo, string descripcion) {
            return base.Channel.ModificarAnuncioAsync(id, titulo, descripcion);
        }
        
        public void EliminarAnuncio(int id) {
            base.Channel.EliminarAnuncio(id);
        }
        
        public System.Threading.Tasks.Task EliminarAnuncioAsync(int id) {
            return base.Channel.EliminarAnuncioAsync(id);
        }
        
        public Reclutamiento.MVC.ReclutamientoWS.Anuncio[] ListarAnuncios() {
            return base.Channel.ListarAnuncios();
        }
        
        public System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Anuncio[]> ListarAnunciosAsync() {
            return base.Channel.ListarAnunciosAsync();
        }
        
        public Reclutamiento.MVC.ReclutamientoWS.Aptitud CrearAptitud(string descripcion) {
            return base.Channel.CrearAptitud(descripcion);
        }
        
        public System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Aptitud> CrearAptitudAsync(string descripcion) {
            return base.Channel.CrearAptitudAsync(descripcion);
        }
        
        public Reclutamiento.MVC.ReclutamientoWS.Aptitud ObtenerAptitud(int id) {
            return base.Channel.ObtenerAptitud(id);
        }
        
        public System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Aptitud> ObtenerAptitudAsync(int id) {
            return base.Channel.ObtenerAptitudAsync(id);
        }
        
        public Reclutamiento.MVC.ReclutamientoWS.Aptitud ModificarAptitud(int id, string descripcion) {
            return base.Channel.ModificarAptitud(id, descripcion);
        }
        
        public System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Aptitud> ModificarAptitudAsync(int id, string descripcion) {
            return base.Channel.ModificarAptitudAsync(id, descripcion);
        }
        
        public void EliminarAptitud(int id) {
            base.Channel.EliminarAptitud(id);
        }
        
        public System.Threading.Tasks.Task EliminarAptitudAsync(int id) {
            return base.Channel.EliminarAptitudAsync(id);
        }
        
        public Reclutamiento.MVC.ReclutamientoWS.Aptitud[] ListarAptitudes() {
            return base.Channel.ListarAptitudes();
        }
        
        public System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Aptitud[]> ListarAptitudesAsync() {
            return base.Channel.ListarAptitudesAsync();
        }
        
        public Reclutamiento.MVC.ReclutamientoWS.Aptitud_Anuncio CrearAptitud_Anuncio(int idAnuncio, int idAptitud) {
            return base.Channel.CrearAptitud_Anuncio(idAnuncio, idAptitud);
        }
        
        public System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Aptitud_Anuncio> CrearAptitud_AnuncioAsync(int idAnuncio, int idAptitud) {
            return base.Channel.CrearAptitud_AnuncioAsync(idAnuncio, idAptitud);
        }
        
        public Reclutamiento.MVC.ReclutamientoWS.Aptitud_Anuncio ObtenerAptitud_Anuncio(int id) {
            return base.Channel.ObtenerAptitud_Anuncio(id);
        }
        
        public System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Aptitud_Anuncio> ObtenerAptitud_AnuncioAsync(int id) {
            return base.Channel.ObtenerAptitud_AnuncioAsync(id);
        }
        
        public Reclutamiento.MVC.ReclutamientoWS.Aptitud_Anuncio ModificarAptitud_Anuncio(int idAnuncio, int idAptitud) {
            return base.Channel.ModificarAptitud_Anuncio(idAnuncio, idAptitud);
        }
        
        public System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Aptitud_Anuncio> ModificarAptitud_AnuncioAsync(int idAnuncio, int idAptitud) {
            return base.Channel.ModificarAptitud_AnuncioAsync(idAnuncio, idAptitud);
        }
        
        public void EliminarAptitud_Anuncio(int id) {
            base.Channel.EliminarAptitud_Anuncio(id);
        }
        
        public System.Threading.Tasks.Task EliminarAptitud_AnuncioAsync(int id) {
            return base.Channel.EliminarAptitud_AnuncioAsync(id);
        }
        
        public Reclutamiento.MVC.ReclutamientoWS.Aptitud_Anuncio[] ListarAptitudesPorAnuncio() {
            return base.Channel.ListarAptitudesPorAnuncio();
        }
        
        public System.Threading.Tasks.Task<Reclutamiento.MVC.ReclutamientoWS.Aptitud_Anuncio[]> ListarAptitudesPorAnuncioAsync() {
            return base.Channel.ListarAptitudesPorAnuncioAsync();
        }
    }
}
