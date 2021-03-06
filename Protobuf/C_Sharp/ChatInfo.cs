// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: chatInfo.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from chatInfo.proto</summary>
public static partial class ChatInfoReflection {

  #region Descriptor
  /// <summary>File descriptor for chatInfo.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static ChatInfoReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "Cg5jaGF0SW5mby5wcm90byLDAQoTY2hhdE1lc3NhZ2VSZXNwb25zZRIeCgdt",
          "c2dUeXBlGAEgASgOMg0ubWVzc2FnZVR5cGVzEg8KB21lc3NhZ2UYAiABKAkS",
          "CwoDY250GAMgASgFEigKBXVzZXJzGAQgAygLMhkuY2hhdE1lc3NhZ2VSZXNw",
          "b25zZS51c2VyEhcKD3NlbGZjb25uZXRpb25JZBgFIAEoCRorCgR1c2VyEhUK",
          "DWNvbm5lY3Rpb25faWQYASABKAkSDAoEbmFtZRgCIAEoCSKyAQoSY2hhdE1l",
          "c3NhZ2VSZXF1ZXN0Eg8KB21lc3NhZ2UYASABKAkSDgoGdG91c2VyGAIgASgJ",
          "EgwKBHVzZXIYAyABKAkSCwoDY250GAQgASgFEg0KBXVzZXJzGAUgAygJEh4K",
          "B21zZ1R5cGUYBiABKA4yDS5tZXNzYWdlVHlwZXMSFwoPc2VsZmNvbm5ldGlv",
          "bklkGAcgASgJEhgKEG90aGVyY29ubmV0aW9uSWQYCCABKAkqNwoMbWVzc2Fn",
          "ZVR5cGVzEhIKDkdldE9ubGluZVVzZXJzEAASBwoDQWxsEAESCgoGcGVyc29u",
          "EAJiBnByb3RvMw=="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(new[] {typeof(global::messageTypes), }, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::chatMessageResponse), global::chatMessageResponse.Parser, new[]{ "MsgType", "Message", "Cnt", "Users", "SelfconnetionId" }, null, null, null, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::chatMessageResponse.Types.user), global::chatMessageResponse.Types.user.Parser, new[]{ "ConnectionId", "Name" }, null, null, null, null)}),
          new pbr::GeneratedClrTypeInfo(typeof(global::chatMessageRequest), global::chatMessageRequest.Parser, new[]{ "Message", "Touser", "User", "Cnt", "Users", "MsgType", "SelfconnetionId", "OtherconnetionId" }, null, null, null, null)
        }));
  }
  #endregion

}
#region Enums
public enum messageTypes {
  [pbr::OriginalName("GetOnlineUsers")] GetOnlineUsers = 0,
  [pbr::OriginalName("All")] All = 1,
  [pbr::OriginalName("person")] Person = 2,
}

#endregion

#region Messages
public sealed partial class chatMessageResponse : pb::IMessage<chatMessageResponse> {
  private static readonly pb::MessageParser<chatMessageResponse> _parser = new pb::MessageParser<chatMessageResponse>(() => new chatMessageResponse());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<chatMessageResponse> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::ChatInfoReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public chatMessageResponse() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public chatMessageResponse(chatMessageResponse other) : this() {
    msgType_ = other.msgType_;
    message_ = other.message_;
    cnt_ = other.cnt_;
    users_ = other.users_.Clone();
    selfconnetionId_ = other.selfconnetionId_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public chatMessageResponse Clone() {
    return new chatMessageResponse(this);
  }

  /// <summary>Field number for the "msgType" field.</summary>
  public const int MsgTypeFieldNumber = 1;
  private global::messageTypes msgType_ = global::messageTypes.GetOnlineUsers;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public global::messageTypes MsgType {
    get { return msgType_; }
    set {
      msgType_ = value;
    }
  }

  /// <summary>Field number for the "message" field.</summary>
  public const int MessageFieldNumber = 2;
  private string message_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Message {
    get { return message_; }
    set {
      message_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "cnt" field.</summary>
  public const int CntFieldNumber = 3;
  private int cnt_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int Cnt {
    get { return cnt_; }
    set {
      cnt_ = value;
    }
  }

  /// <summary>Field number for the "users" field.</summary>
  public const int UsersFieldNumber = 4;
  private static readonly pb::FieldCodec<global::chatMessageResponse.Types.user> _repeated_users_codec
      = pb::FieldCodec.ForMessage(34, global::chatMessageResponse.Types.user.Parser);
  private readonly pbc::RepeatedField<global::chatMessageResponse.Types.user> users_ = new pbc::RepeatedField<global::chatMessageResponse.Types.user>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public pbc::RepeatedField<global::chatMessageResponse.Types.user> Users {
    get { return users_; }
  }

  /// <summary>Field number for the "selfconnetionId" field.</summary>
  public const int SelfconnetionIdFieldNumber = 5;
  private string selfconnetionId_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string SelfconnetionId {
    get { return selfconnetionId_; }
    set {
      selfconnetionId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as chatMessageResponse);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(chatMessageResponse other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (MsgType != other.MsgType) return false;
    if (Message != other.Message) return false;
    if (Cnt != other.Cnt) return false;
    if(!users_.Equals(other.users_)) return false;
    if (SelfconnetionId != other.SelfconnetionId) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (MsgType != global::messageTypes.GetOnlineUsers) hash ^= MsgType.GetHashCode();
    if (Message.Length != 0) hash ^= Message.GetHashCode();
    if (Cnt != 0) hash ^= Cnt.GetHashCode();
    hash ^= users_.GetHashCode();
    if (SelfconnetionId.Length != 0) hash ^= SelfconnetionId.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void WriteTo(pb::CodedOutputStream output) {
    if (MsgType != global::messageTypes.GetOnlineUsers) {
      output.WriteRawTag(8);
      output.WriteEnum((int) MsgType);
    }
    if (Message.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Message);
    }
    if (Cnt != 0) {
      output.WriteRawTag(24);
      output.WriteInt32(Cnt);
    }
    users_.WriteTo(output, _repeated_users_codec);
    if (SelfconnetionId.Length != 0) {
      output.WriteRawTag(42);
      output.WriteString(SelfconnetionId);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (MsgType != global::messageTypes.GetOnlineUsers) {
      size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) MsgType);
    }
    if (Message.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Message);
    }
    if (Cnt != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(Cnt);
    }
    size += users_.CalculateSize(_repeated_users_codec);
    if (SelfconnetionId.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(SelfconnetionId);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(chatMessageResponse other) {
    if (other == null) {
      return;
    }
    if (other.MsgType != global::messageTypes.GetOnlineUsers) {
      MsgType = other.MsgType;
    }
    if (other.Message.Length != 0) {
      Message = other.Message;
    }
    if (other.Cnt != 0) {
      Cnt = other.Cnt;
    }
    users_.Add(other.users_);
    if (other.SelfconnetionId.Length != 0) {
      SelfconnetionId = other.SelfconnetionId;
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(pb::CodedInputStream input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 8: {
          MsgType = (global::messageTypes) input.ReadEnum();
          break;
        }
        case 18: {
          Message = input.ReadString();
          break;
        }
        case 24: {
          Cnt = input.ReadInt32();
          break;
        }
        case 34: {
          users_.AddEntriesFrom(input, _repeated_users_codec);
          break;
        }
        case 42: {
          SelfconnetionId = input.ReadString();
          break;
        }
      }
    }
  }

  #region Nested types
  /// <summary>Container for nested types declared in the chatMessageResponse message type.</summary>
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static partial class Types {
    public sealed partial class user : pb::IMessage<user> {
      private static readonly pb::MessageParser<user> _parser = new pb::MessageParser<user>(() => new user());
      private pb::UnknownFieldSet _unknownFields;
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public static pb::MessageParser<user> Parser { get { return _parser; } }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public static pbr::MessageDescriptor Descriptor {
        get { return global::chatMessageResponse.Descriptor.NestedTypes[0]; }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      pbr::MessageDescriptor pb::IMessage.Descriptor {
        get { return Descriptor; }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public user() {
        OnConstruction();
      }

      partial void OnConstruction();

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public user(user other) : this() {
        connectionId_ = other.connectionId_;
        name_ = other.name_;
        _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public user Clone() {
        return new user(this);
      }

      /// <summary>Field number for the "connection_id" field.</summary>
      public const int ConnectionIdFieldNumber = 1;
      private string connectionId_ = "";
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public string ConnectionId {
        get { return connectionId_; }
        set {
          connectionId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
        }
      }

      /// <summary>Field number for the "name" field.</summary>
      public const int NameFieldNumber = 2;
      private string name_ = "";
      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public string Name {
        get { return name_; }
        set {
          name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
        }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public override bool Equals(object other) {
        return Equals(other as user);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public bool Equals(user other) {
        if (ReferenceEquals(other, null)) {
          return false;
        }
        if (ReferenceEquals(other, this)) {
          return true;
        }
        if (ConnectionId != other.ConnectionId) return false;
        if (Name != other.Name) return false;
        return Equals(_unknownFields, other._unknownFields);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public override int GetHashCode() {
        int hash = 1;
        if (ConnectionId.Length != 0) hash ^= ConnectionId.GetHashCode();
        if (Name.Length != 0) hash ^= Name.GetHashCode();
        if (_unknownFields != null) {
          hash ^= _unknownFields.GetHashCode();
        }
        return hash;
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public override string ToString() {
        return pb::JsonFormatter.ToDiagnosticString(this);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public void WriteTo(pb::CodedOutputStream output) {
        if (ConnectionId.Length != 0) {
          output.WriteRawTag(10);
          output.WriteString(ConnectionId);
        }
        if (Name.Length != 0) {
          output.WriteRawTag(18);
          output.WriteString(Name);
        }
        if (_unknownFields != null) {
          _unknownFields.WriteTo(output);
        }
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public int CalculateSize() {
        int size = 0;
        if (ConnectionId.Length != 0) {
          size += 1 + pb::CodedOutputStream.ComputeStringSize(ConnectionId);
        }
        if (Name.Length != 0) {
          size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
        }
        if (_unknownFields != null) {
          size += _unknownFields.CalculateSize();
        }
        return size;
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public void MergeFrom(user other) {
        if (other == null) {
          return;
        }
        if (other.ConnectionId.Length != 0) {
          ConnectionId = other.ConnectionId;
        }
        if (other.Name.Length != 0) {
          Name = other.Name;
        }
        _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
      }

      [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
      public void MergeFrom(pb::CodedInputStream input) {
        uint tag;
        while ((tag = input.ReadTag()) != 0) {
          switch(tag) {
            default:
              _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
              break;
            case 10: {
              ConnectionId = input.ReadString();
              break;
            }
            case 18: {
              Name = input.ReadString();
              break;
            }
          }
        }
      }

    }

  }
  #endregion

}

public sealed partial class chatMessageRequest : pb::IMessage<chatMessageRequest> {
  private static readonly pb::MessageParser<chatMessageRequest> _parser = new pb::MessageParser<chatMessageRequest>(() => new chatMessageRequest());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<chatMessageRequest> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::ChatInfoReflection.Descriptor.MessageTypes[1]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public chatMessageRequest() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public chatMessageRequest(chatMessageRequest other) : this() {
    message_ = other.message_;
    touser_ = other.touser_;
    user_ = other.user_;
    cnt_ = other.cnt_;
    users_ = other.users_.Clone();
    msgType_ = other.msgType_;
    selfconnetionId_ = other.selfconnetionId_;
    otherconnetionId_ = other.otherconnetionId_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public chatMessageRequest Clone() {
    return new chatMessageRequest(this);
  }

  /// <summary>Field number for the "message" field.</summary>
  public const int MessageFieldNumber = 1;
  private string message_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Message {
    get { return message_; }
    set {
      message_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "touser" field.</summary>
  public const int TouserFieldNumber = 2;
  private string touser_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Touser {
    get { return touser_; }
    set {
      touser_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "user" field.</summary>
  public const int UserFieldNumber = 3;
  private string user_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string User {
    get { return user_; }
    set {
      user_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "cnt" field.</summary>
  public const int CntFieldNumber = 4;
  private int cnt_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int Cnt {
    get { return cnt_; }
    set {
      cnt_ = value;
    }
  }

  /// <summary>Field number for the "users" field.</summary>
  public const int UsersFieldNumber = 5;
  private static readonly pb::FieldCodec<string> _repeated_users_codec
      = pb::FieldCodec.ForString(42);
  private readonly pbc::RepeatedField<string> users_ = new pbc::RepeatedField<string>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public pbc::RepeatedField<string> Users {
    get { return users_; }
  }

  /// <summary>Field number for the "msgType" field.</summary>
  public const int MsgTypeFieldNumber = 6;
  private global::messageTypes msgType_ = global::messageTypes.GetOnlineUsers;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public global::messageTypes MsgType {
    get { return msgType_; }
    set {
      msgType_ = value;
    }
  }

  /// <summary>Field number for the "selfconnetionId" field.</summary>
  public const int SelfconnetionIdFieldNumber = 7;
  private string selfconnetionId_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string SelfconnetionId {
    get { return selfconnetionId_; }
    set {
      selfconnetionId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "otherconnetionId" field.</summary>
  public const int OtherconnetionIdFieldNumber = 8;
  private string otherconnetionId_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string OtherconnetionId {
    get { return otherconnetionId_; }
    set {
      otherconnetionId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as chatMessageRequest);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(chatMessageRequest other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Message != other.Message) return false;
    if (Touser != other.Touser) return false;
    if (User != other.User) return false;
    if (Cnt != other.Cnt) return false;
    if(!users_.Equals(other.users_)) return false;
    if (MsgType != other.MsgType) return false;
    if (SelfconnetionId != other.SelfconnetionId) return false;
    if (OtherconnetionId != other.OtherconnetionId) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (Message.Length != 0) hash ^= Message.GetHashCode();
    if (Touser.Length != 0) hash ^= Touser.GetHashCode();
    if (User.Length != 0) hash ^= User.GetHashCode();
    if (Cnt != 0) hash ^= Cnt.GetHashCode();
    hash ^= users_.GetHashCode();
    if (MsgType != global::messageTypes.GetOnlineUsers) hash ^= MsgType.GetHashCode();
    if (SelfconnetionId.Length != 0) hash ^= SelfconnetionId.GetHashCode();
    if (OtherconnetionId.Length != 0) hash ^= OtherconnetionId.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void WriteTo(pb::CodedOutputStream output) {
    if (Message.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Message);
    }
    if (Touser.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Touser);
    }
    if (User.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(User);
    }
    if (Cnt != 0) {
      output.WriteRawTag(32);
      output.WriteInt32(Cnt);
    }
    users_.WriteTo(output, _repeated_users_codec);
    if (MsgType != global::messageTypes.GetOnlineUsers) {
      output.WriteRawTag(48);
      output.WriteEnum((int) MsgType);
    }
    if (SelfconnetionId.Length != 0) {
      output.WriteRawTag(58);
      output.WriteString(SelfconnetionId);
    }
    if (OtherconnetionId.Length != 0) {
      output.WriteRawTag(66);
      output.WriteString(OtherconnetionId);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (Message.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Message);
    }
    if (Touser.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Touser);
    }
    if (User.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(User);
    }
    if (Cnt != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(Cnt);
    }
    size += users_.CalculateSize(_repeated_users_codec);
    if (MsgType != global::messageTypes.GetOnlineUsers) {
      size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) MsgType);
    }
    if (SelfconnetionId.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(SelfconnetionId);
    }
    if (OtherconnetionId.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(OtherconnetionId);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(chatMessageRequest other) {
    if (other == null) {
      return;
    }
    if (other.Message.Length != 0) {
      Message = other.Message;
    }
    if (other.Touser.Length != 0) {
      Touser = other.Touser;
    }
    if (other.User.Length != 0) {
      User = other.User;
    }
    if (other.Cnt != 0) {
      Cnt = other.Cnt;
    }
    users_.Add(other.users_);
    if (other.MsgType != global::messageTypes.GetOnlineUsers) {
      MsgType = other.MsgType;
    }
    if (other.SelfconnetionId.Length != 0) {
      SelfconnetionId = other.SelfconnetionId;
    }
    if (other.OtherconnetionId.Length != 0) {
      OtherconnetionId = other.OtherconnetionId;
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(pb::CodedInputStream input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          Message = input.ReadString();
          break;
        }
        case 18: {
          Touser = input.ReadString();
          break;
        }
        case 26: {
          User = input.ReadString();
          break;
        }
        case 32: {
          Cnt = input.ReadInt32();
          break;
        }
        case 42: {
          users_.AddEntriesFrom(input, _repeated_users_codec);
          break;
        }
        case 48: {
          MsgType = (global::messageTypes) input.ReadEnum();
          break;
        }
        case 58: {
          SelfconnetionId = input.ReadString();
          break;
        }
        case 66: {
          OtherconnetionId = input.ReadString();
          break;
        }
      }
    }
  }

}

#endregion


#endregion Designer generated code
