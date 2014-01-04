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
  public partial class Certificate : TBase
  {
    private string _HexDigitsKey;
    private Signature _Sig;
    private ArchiveInfo _RelatedArchive;
    private string _LocalID;

    public string HexDigitsKey
    {
      get
      {
        return _HexDigitsKey;
      }
      set
      {
        __isset.HexDigitsKey = true;
        this._HexDigitsKey = value;
      }
    }

    public Signature Sig
    {
      get
      {
        return _Sig;
      }
      set
      {
        __isset.Sig = true;
        this._Sig = value;
      }
    }

    public ArchiveInfo RelatedArchive
    {
      get
      {
        return _RelatedArchive;
      }
      set
      {
        __isset.RelatedArchive = true;
        this._RelatedArchive = value;
      }
    }

    public string LocalID
    {
      get
      {
        return _LocalID;
      }
      set
      {
        __isset.LocalID = true;
        this._LocalID = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool HexDigitsKey;
      public bool Sig;
      public bool RelatedArchive;
      public bool LocalID;
    }

    public Certificate() {
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
              HexDigitsKey = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.Struct) {
              Sig = new Signature();
              Sig.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Struct) {
              RelatedArchive = new ArchiveInfo();
              RelatedArchive.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.String) {
              LocalID = iprot.ReadString();
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
      TStruct struc = new TStruct("Certificate");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (HexDigitsKey != null && __isset.HexDigitsKey) {
        field.Name = "HexDigitsKey";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(HexDigitsKey);
        oprot.WriteFieldEnd();
      }
      if (Sig != null && __isset.Sig) {
        field.Name = "Sig";
        field.Type = TType.Struct;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        Sig.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (RelatedArchive != null && __isset.RelatedArchive) {
        field.Name = "RelatedArchive";
        field.Type = TType.Struct;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        RelatedArchive.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (LocalID != null && __isset.LocalID) {
        field.Name = "LocalID";
        field.Type = TType.String;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(LocalID);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("Certificate(");
      sb.Append("HexDigitsKey: ");
      sb.Append(HexDigitsKey);
      sb.Append(",Sig: ");
      sb.Append(Sig== null ? "<null>" : Sig.ToString());
      sb.Append(",RelatedArchive: ");
      sb.Append(RelatedArchive== null ? "<null>" : RelatedArchive.ToString());
      sb.Append(",LocalID: ");
      sb.Append(LocalID);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
