/**
 * Autogenerated by Thrift Compiler (0.9.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace ThriftInterface
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Capsule : TBase
  {
    private string _Created;
    private string _ID;
    private string _Resource_URI;
    private string _Title;
    private string _User;
    private DateInfo _ExpirationDate;
    private long _TotalSizeInBytes;
    private long _AvailableSizeInBytes;
    private List<ArchiveInfo> _CapsuleContents;

    public string Created
    {
      get
      {
        return _Created;
      }
      set
      {
        __isset.Created = true;
        this._Created = value;
      }
    }

    public string ID
    {
      get
      {
        return _ID;
      }
      set
      {
        __isset.ID = true;
        this._ID = value;
      }
    }

    public string Resource_URI
    {
      get
      {
        return _Resource_URI;
      }
      set
      {
        __isset.Resource_URI = true;
        this._Resource_URI = value;
      }
    }

    public string Title
    {
      get
      {
        return _Title;
      }
      set
      {
        __isset.Title = true;
        this._Title = value;
      }
    }

    public string User
    {
      get
      {
        return _User;
      }
      set
      {
        __isset.User = true;
        this._User = value;
      }
    }

    public DateInfo ExpirationDate
    {
      get
      {
        return _ExpirationDate;
      }
      set
      {
        __isset.ExpirationDate = true;
        this._ExpirationDate = value;
      }
    }

    public long TotalSizeInBytes
    {
      get
      {
        return _TotalSizeInBytes;
      }
      set
      {
        __isset.TotalSizeInBytes = true;
        this._TotalSizeInBytes = value;
      }
    }

    public long AvailableSizeInBytes
    {
      get
      {
        return _AvailableSizeInBytes;
      }
      set
      {
        __isset.AvailableSizeInBytes = true;
        this._AvailableSizeInBytes = value;
      }
    }

    public List<ArchiveInfo> CapsuleContents
    {
      get
      {
        return _CapsuleContents;
      }
      set
      {
        __isset.CapsuleContents = true;
        this._CapsuleContents = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool Created;
      public bool ID;
      public bool Resource_URI;
      public bool Title;
      public bool User;
      public bool ExpirationDate;
      public bool TotalSizeInBytes;
      public bool AvailableSizeInBytes;
      public bool CapsuleContents;
    }

    public Capsule() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.String) {
              Created = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              ID = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.String) {
              Resource_URI = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.String) {
              Title = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.String) {
              User = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.Struct) {
              ExpirationDate = new DateInfo();
              ExpirationDate.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.I64) {
              TotalSizeInBytes = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 8:
            if (field.Type == TType.I64) {
              AvailableSizeInBytes = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 9:
            if (field.Type == TType.List) {
              {
                CapsuleContents = new List<ArchiveInfo>();
                TList _list0 = iprot.ReadListBegin();
                for( int _i1 = 0; _i1 < _list0.Count; ++_i1)
                {
                  ArchiveInfo _elem2 = new ArchiveInfo();
                  _elem2 = new ArchiveInfo();
                  _elem2.Read(iprot);
                  CapsuleContents.Add(_elem2);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("Capsule");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Created != null && __isset.Created) {
        field.Name = "Created";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Created);
        oprot.WriteFieldEnd();
      }
      if (ID != null && __isset.ID) {
        field.Name = "ID";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ID);
        oprot.WriteFieldEnd();
      }
      if (Resource_URI != null && __isset.Resource_URI) {
        field.Name = "Resource_URI";
        field.Type = TType.String;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Resource_URI);
        oprot.WriteFieldEnd();
      }
      if (Title != null && __isset.Title) {
        field.Name = "Title";
        field.Type = TType.String;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Title);
        oprot.WriteFieldEnd();
      }
      if (User != null && __isset.User) {
        field.Name = "User";
        field.Type = TType.String;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(User);
        oprot.WriteFieldEnd();
      }
      if (ExpirationDate != null && __isset.ExpirationDate) {
        field.Name = "ExpirationDate";
        field.Type = TType.Struct;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        ExpirationDate.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (__isset.TotalSizeInBytes) {
        field.Name = "TotalSizeInBytes";
        field.Type = TType.I64;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(TotalSizeInBytes);
        oprot.WriteFieldEnd();
      }
      if (__isset.AvailableSizeInBytes) {
        field.Name = "AvailableSizeInBytes";
        field.Type = TType.I64;
        field.ID = 8;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(AvailableSizeInBytes);
        oprot.WriteFieldEnd();
      }
      if (CapsuleContents != null && __isset.CapsuleContents) {
        field.Name = "CapsuleContents";
        field.Type = TType.List;
        field.ID = 9;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, CapsuleContents.Count));
          foreach (ArchiveInfo _iter3 in CapsuleContents)
          {
            _iter3.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("Capsule(");
      sb.Append("Created: ");
      sb.Append(Created);
      sb.Append(",ID: ");
      sb.Append(ID);
      sb.Append(",Resource_URI: ");
      sb.Append(Resource_URI);
      sb.Append(",Title: ");
      sb.Append(Title);
      sb.Append(",User: ");
      sb.Append(User);
      sb.Append(",ExpirationDate: ");
      sb.Append(ExpirationDate== null ? "<null>" : ExpirationDate.ToString());
      sb.Append(",TotalSizeInBytes: ");
      sb.Append(TotalSizeInBytes);
      sb.Append(",AvailableSizeInBytes: ");
      sb.Append(AvailableSizeInBytes);
      sb.Append(",CapsuleContents: ");
      sb.Append(CapsuleContents);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
