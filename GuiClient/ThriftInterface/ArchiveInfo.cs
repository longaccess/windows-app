/**
 * Autogenerated by Thrift Compiler (0.9.0)
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
  public partial class ArchiveInfo : TBase
  {
    private string _Title;
    private string _Description;
    private long _SizeInBytes;
    private DateInfo _CreatedDate;
    private string _Md5HexDigits;

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

    public string Description
    {
      get
      {
        return _Description;
      }
      set
      {
        __isset.Description = true;
        this._Description = value;
      }
    }

    public long SizeInBytes
    {
      get
      {
        return _SizeInBytes;
      }
      set
      {
        __isset.SizeInBytes = true;
        this._SizeInBytes = value;
      }
    }

    public DateInfo CreatedDate
    {
      get
      {
        return _CreatedDate;
      }
      set
      {
        __isset.CreatedDate = true;
        this._CreatedDate = value;
      }
    }

    public string Md5HexDigits
    {
      get
      {
        return _Md5HexDigits;
      }
      set
      {
        __isset.Md5HexDigits = true;
        this._Md5HexDigits = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool Title;
      public bool Description;
      public bool SizeInBytes;
      public bool CreatedDate;
      public bool Md5HexDigits;
    }

    public ArchiveInfo() {
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
              Title = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              Description = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.I64) {
              SizeInBytes = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Struct) {
              CreatedDate = new DateInfo();
              CreatedDate.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.String) {
              Md5HexDigits = iprot.ReadString();
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
      TStruct struc = new TStruct("ArchiveInfo");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Title != null && __isset.Title) {
        field.Name = "Title";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Title);
        oprot.WriteFieldEnd();
      }
      if (Description != null && __isset.Description) {
        field.Name = "Description";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Description);
        oprot.WriteFieldEnd();
      }
      if (__isset.SizeInBytes) {
        field.Name = "SizeInBytes";
        field.Type = TType.I64;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(SizeInBytes);
        oprot.WriteFieldEnd();
      }
      if (CreatedDate != null && __isset.CreatedDate) {
        field.Name = "CreatedDate";
        field.Type = TType.Struct;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        CreatedDate.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Md5HexDigits != null && __isset.Md5HexDigits) {
        field.Name = "Md5HexDigits";
        field.Type = TType.String;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Md5HexDigits);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("ArchiveInfo(");
      sb.Append("Title: ");
      sb.Append(Title);
      sb.Append(",Description: ");
      sb.Append(Description);
      sb.Append(",SizeInBytes: ");
      sb.Append(SizeInBytes);
      sb.Append(",CreatedDate: ");
      sb.Append(CreatedDate== null ? "<null>" : CreatedDate.ToString());
      sb.Append(",Md5HexDigits: ");
      sb.Append(Md5HexDigits);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
