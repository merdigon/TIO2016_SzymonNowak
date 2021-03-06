﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiteDBClient.MovieRepository {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RepositoryModelBase", Namespace="http://schemas.datacontract.org/2004/07/LiteDBService.DBProvider.BaseObjects")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(LiteDBClient.MovieRepository.Movie))]
    public partial class RepositoryModelBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Movie", Namespace="http://schemas.datacontract.org/2004/07/ModelLibrary")]
    [System.SerializableAttribute()]
    public partial class Movie : LiteDBClient.MovieRepository.RepositoryModelBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ReleaseYearField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ReleaseYear {
            get {
                return this.ReleaseYearField;
            }
            set {
                if ((this.ReleaseYearField.Equals(value) != true)) {
                    this.ReleaseYearField = value;
                    this.RaisePropertyChanged("ReleaseYear");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MovieRepository.IMovieRepositoryService")]
    public interface IMovieRepositoryService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovieRepositoryService/CreateMovie", ReplyAction="http://tempuri.org/IMovieRepositoryService/CreateMovieResponse")]
        int CreateMovie(LiteDBClient.MovieRepository.Movie model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovieRepositoryService/CreateMovie", ReplyAction="http://tempuri.org/IMovieRepositoryService/CreateMovieResponse")]
        System.Threading.Tasks.Task<int> CreateMovieAsync(LiteDBClient.MovieRepository.Movie model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovieRepositoryService/ReadMovie", ReplyAction="http://tempuri.org/IMovieRepositoryService/ReadMovieResponse")]
        LiteDBClient.MovieRepository.Movie ReadMovie(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovieRepositoryService/ReadMovie", ReplyAction="http://tempuri.org/IMovieRepositoryService/ReadMovieResponse")]
        System.Threading.Tasks.Task<LiteDBClient.MovieRepository.Movie> ReadMovieAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovieRepositoryService/ReadMovies", ReplyAction="http://tempuri.org/IMovieRepositoryService/ReadMoviesResponse")]
        LiteDBClient.MovieRepository.Movie[] ReadMovies(int[] ids);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovieRepositoryService/ReadMovies", ReplyAction="http://tempuri.org/IMovieRepositoryService/ReadMoviesResponse")]
        System.Threading.Tasks.Task<LiteDBClient.MovieRepository.Movie[]> ReadMoviesAsync(int[] ids);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovieRepositoryService/ReadAllMovies", ReplyAction="http://tempuri.org/IMovieRepositoryService/ReadAllMoviesResponse")]
        LiteDBClient.MovieRepository.Movie[] ReadAllMovies();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovieRepositoryService/ReadAllMovies", ReplyAction="http://tempuri.org/IMovieRepositoryService/ReadAllMoviesResponse")]
        System.Threading.Tasks.Task<LiteDBClient.MovieRepository.Movie[]> ReadAllMoviesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovieRepositoryService/UpdateMovie", ReplyAction="http://tempuri.org/IMovieRepositoryService/UpdateMovieResponse")]
        LiteDBClient.MovieRepository.Movie UpdateMovie(LiteDBClient.MovieRepository.Movie model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovieRepositoryService/UpdateMovie", ReplyAction="http://tempuri.org/IMovieRepositoryService/UpdateMovieResponse")]
        System.Threading.Tasks.Task<LiteDBClient.MovieRepository.Movie> UpdateMovieAsync(LiteDBClient.MovieRepository.Movie model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovieRepositoryService/DeleteMovie", ReplyAction="http://tempuri.org/IMovieRepositoryService/DeleteMovieResponse")]
        bool DeleteMovie(LiteDBClient.MovieRepository.Movie model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMovieRepositoryService/DeleteMovie", ReplyAction="http://tempuri.org/IMovieRepositoryService/DeleteMovieResponse")]
        System.Threading.Tasks.Task<bool> DeleteMovieAsync(LiteDBClient.MovieRepository.Movie model);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMovieRepositoryServiceChannel : LiteDBClient.MovieRepository.IMovieRepositoryService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MovieRepositoryServiceClient : System.ServiceModel.ClientBase<LiteDBClient.MovieRepository.IMovieRepositoryService>, LiteDBClient.MovieRepository.IMovieRepositoryService {
        
        public MovieRepositoryServiceClient() {
        }
        
        public MovieRepositoryServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MovieRepositoryServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MovieRepositoryServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MovieRepositoryServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int CreateMovie(LiteDBClient.MovieRepository.Movie model) {
            return base.Channel.CreateMovie(model);
        }
        
        public System.Threading.Tasks.Task<int> CreateMovieAsync(LiteDBClient.MovieRepository.Movie model) {
            return base.Channel.CreateMovieAsync(model);
        }
        
        public LiteDBClient.MovieRepository.Movie ReadMovie(int id) {
            return base.Channel.ReadMovie(id);
        }
        
        public System.Threading.Tasks.Task<LiteDBClient.MovieRepository.Movie> ReadMovieAsync(int id) {
            return base.Channel.ReadMovieAsync(id);
        }
        
        public LiteDBClient.MovieRepository.Movie[] ReadMovies(int[] ids) {
            return base.Channel.ReadMovies(ids);
        }
        
        public System.Threading.Tasks.Task<LiteDBClient.MovieRepository.Movie[]> ReadMoviesAsync(int[] ids) {
            return base.Channel.ReadMoviesAsync(ids);
        }
        
        public LiteDBClient.MovieRepository.Movie[] ReadAllMovies() {
            return base.Channel.ReadAllMovies();
        }
        
        public System.Threading.Tasks.Task<LiteDBClient.MovieRepository.Movie[]> ReadAllMoviesAsync() {
            return base.Channel.ReadAllMoviesAsync();
        }
        
        public LiteDBClient.MovieRepository.Movie UpdateMovie(LiteDBClient.MovieRepository.Movie model) {
            return base.Channel.UpdateMovie(model);
        }
        
        public System.Threading.Tasks.Task<LiteDBClient.MovieRepository.Movie> UpdateMovieAsync(LiteDBClient.MovieRepository.Movie model) {
            return base.Channel.UpdateMovieAsync(model);
        }
        
        public bool DeleteMovie(LiteDBClient.MovieRepository.Movie model) {
            return base.Channel.DeleteMovie(model);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteMovieAsync(LiteDBClient.MovieRepository.Movie model) {
            return base.Channel.DeleteMovieAsync(model);
        }
    }
}
