// source: chatInfo.proto
/**
 * @fileoverview
 * @enhanceable
 * @suppress {messageConventions} JS Compiler reports an error if a variable or
 *     field starts with 'MSG_' and isn't a translatable message.
 * @public
 */
// GENERATED CODE -- DO NOT EDIT!

var jspb = require('google-protobuf');
var goog = jspb;
var global = Function('return this')();

goog.exportSymbol('proto.chatMessageRequest', null, global);
goog.exportSymbol('proto.chatMessageResponse', null, global);
goog.exportSymbol('proto.chatMessageResponse.user', null, global);
goog.exportSymbol('proto.messageTypes', null, global);
/**
 * Generated by JsPbCodeGenerator.
 * @param {Array=} opt_data Optional initial data array, typically from a
 * server response, or constructed directly in Javascript. The array is used
 * in place and becomes part of the constructed object. It is not cloned.
 * If no data is provided, the constructed object will be empty, but still
 * valid.
 * @extends {jspb.Message}
 * @constructor
 */
proto.chatMessageResponse = function(opt_data) {
  jspb.Message.initialize(this, opt_data, 0, -1, proto.chatMessageResponse.repeatedFields_, null);
};
goog.inherits(proto.chatMessageResponse, jspb.Message);
if (goog.DEBUG && !COMPILED) {
  /**
   * @public
   * @override
   */
  proto.chatMessageResponse.displayName = 'proto.chatMessageResponse';
}
/**
 * Generated by JsPbCodeGenerator.
 * @param {Array=} opt_data Optional initial data array, typically from a
 * server response, or constructed directly in Javascript. The array is used
 * in place and becomes part of the constructed object. It is not cloned.
 * If no data is provided, the constructed object will be empty, but still
 * valid.
 * @extends {jspb.Message}
 * @constructor
 */
proto.chatMessageResponse.user = function(opt_data) {
  jspb.Message.initialize(this, opt_data, 0, -1, null, null);
};
goog.inherits(proto.chatMessageResponse.user, jspb.Message);
if (goog.DEBUG && !COMPILED) {
  /**
   * @public
   * @override
   */
  proto.chatMessageResponse.user.displayName = 'proto.chatMessageResponse.user';
}
/**
 * Generated by JsPbCodeGenerator.
 * @param {Array=} opt_data Optional initial data array, typically from a
 * server response, or constructed directly in Javascript. The array is used
 * in place and becomes part of the constructed object. It is not cloned.
 * If no data is provided, the constructed object will be empty, but still
 * valid.
 * @extends {jspb.Message}
 * @constructor
 */
proto.chatMessageRequest = function(opt_data) {
  jspb.Message.initialize(this, opt_data, 0, -1, proto.chatMessageRequest.repeatedFields_, null);
};
goog.inherits(proto.chatMessageRequest, jspb.Message);
if (goog.DEBUG && !COMPILED) {
  /**
   * @public
   * @override
   */
  proto.chatMessageRequest.displayName = 'proto.chatMessageRequest';
}

/**
 * List of repeated fields within this message type.
 * @private {!Array<number>}
 * @const
 */
proto.chatMessageResponse.repeatedFields_ = [4];



if (jspb.Message.GENERATE_TO_OBJECT) {
/**
 * Creates an object representation of this proto.
 * Field names that are reserved in JavaScript and will be renamed to pb_name.
 * Optional fields that are not set will be set to undefined.
 * To access a reserved field use, foo.pb_<name>, eg, foo.pb_default.
 * For the list of reserved names please see:
 *     net/proto2/compiler/js/internal/generator.cc#kKeyword.
 * @param {boolean=} opt_includeInstance Deprecated. whether to include the
 *     JSPB instance for transitional soy proto support:
 *     http://goto/soy-param-migration
 * @return {!Object}
 */
proto.chatMessageResponse.prototype.toObject = function(opt_includeInstance) {
  return proto.chatMessageResponse.toObject(opt_includeInstance, this);
};


/**
 * Static version of the {@see toObject} method.
 * @param {boolean|undefined} includeInstance Deprecated. Whether to include
 *     the JSPB instance for transitional soy proto support:
 *     http://goto/soy-param-migration
 * @param {!proto.chatMessageResponse} msg The msg instance to transform.
 * @return {!Object}
 * @suppress {unusedLocalVariables} f is only used for nested messages
 */
proto.chatMessageResponse.toObject = function(includeInstance, msg) {
  var f, obj = {
    msgtype: jspb.Message.getFieldWithDefault(msg, 1, 0),
    message: jspb.Message.getFieldWithDefault(msg, 2, ""),
    cnt: jspb.Message.getFieldWithDefault(msg, 3, 0),
    usersList: jspb.Message.toObjectList(msg.getUsersList(),
    proto.chatMessageResponse.user.toObject, includeInstance),
    selfconnetionid: jspb.Message.getFieldWithDefault(msg, 5, "")
  };

  if (includeInstance) {
    obj.$jspbMessageInstance = msg;
  }
  return obj;
};
}


/**
 * Deserializes binary data (in protobuf wire format).
 * @param {jspb.ByteSource} bytes The bytes to deserialize.
 * @return {!proto.chatMessageResponse}
 */
proto.chatMessageResponse.deserializeBinary = function(bytes) {
  var reader = new jspb.BinaryReader(bytes);
  var msg = new proto.chatMessageResponse;
  return proto.chatMessageResponse.deserializeBinaryFromReader(msg, reader);
};


/**
 * Deserializes binary data (in protobuf wire format) from the
 * given reader into the given message object.
 * @param {!proto.chatMessageResponse} msg The message object to deserialize into.
 * @param {!jspb.BinaryReader} reader The BinaryReader to use.
 * @return {!proto.chatMessageResponse}
 */
proto.chatMessageResponse.deserializeBinaryFromReader = function(msg, reader) {
  while (reader.nextField()) {
    if (reader.isEndGroup()) {
      break;
    }
    var field = reader.getFieldNumber();
    switch (field) {
    case 1:
      var value = /** @type {!proto.messageTypes} */ (reader.readEnum());
      msg.setMsgtype(value);
      break;
    case 2:
      var value = /** @type {string} */ (reader.readString());
      msg.setMessage(value);
      break;
    case 3:
      var value = /** @type {number} */ (reader.readInt32());
      msg.setCnt(value);
      break;
    case 4:
      var value = new proto.chatMessageResponse.user;
      reader.readMessage(value,proto.chatMessageResponse.user.deserializeBinaryFromReader);
      msg.addUsers(value);
      break;
    case 5:
      var value = /** @type {string} */ (reader.readString());
      msg.setSelfconnetionid(value);
      break;
    default:
      reader.skipField();
      break;
    }
  }
  return msg;
};


/**
 * Serializes the message to binary data (in protobuf wire format).
 * @return {!Uint8Array}
 */
proto.chatMessageResponse.prototype.serializeBinary = function() {
  var writer = new jspb.BinaryWriter();
  proto.chatMessageResponse.serializeBinaryToWriter(this, writer);
  return writer.getResultBuffer();
};


/**
 * Serializes the given message to binary data (in protobuf wire
 * format), writing to the given BinaryWriter.
 * @param {!proto.chatMessageResponse} message
 * @param {!jspb.BinaryWriter} writer
 * @suppress {unusedLocalVariables} f is only used for nested messages
 */
proto.chatMessageResponse.serializeBinaryToWriter = function(message, writer) {
  var f = undefined;
  f = message.getMsgtype();
  if (f !== 0.0) {
    writer.writeEnum(
      1,
      f
    );
  }
  f = message.getMessage();
  if (f.length > 0) {
    writer.writeString(
      2,
      f
    );
  }
  f = message.getCnt();
  if (f !== 0) {
    writer.writeInt32(
      3,
      f
    );
  }
  f = message.getUsersList();
  if (f.length > 0) {
    writer.writeRepeatedMessage(
      4,
      f,
      proto.chatMessageResponse.user.serializeBinaryToWriter
    );
  }
  f = message.getSelfconnetionid();
  if (f.length > 0) {
    writer.writeString(
      5,
      f
    );
  }
};





if (jspb.Message.GENERATE_TO_OBJECT) {
/**
 * Creates an object representation of this proto.
 * Field names that are reserved in JavaScript and will be renamed to pb_name.
 * Optional fields that are not set will be set to undefined.
 * To access a reserved field use, foo.pb_<name>, eg, foo.pb_default.
 * For the list of reserved names please see:
 *     net/proto2/compiler/js/internal/generator.cc#kKeyword.
 * @param {boolean=} opt_includeInstance Deprecated. whether to include the
 *     JSPB instance for transitional soy proto support:
 *     http://goto/soy-param-migration
 * @return {!Object}
 */
proto.chatMessageResponse.user.prototype.toObject = function(opt_includeInstance) {
  return proto.chatMessageResponse.user.toObject(opt_includeInstance, this);
};


/**
 * Static version of the {@see toObject} method.
 * @param {boolean|undefined} includeInstance Deprecated. Whether to include
 *     the JSPB instance for transitional soy proto support:
 *     http://goto/soy-param-migration
 * @param {!proto.chatMessageResponse.user} msg The msg instance to transform.
 * @return {!Object}
 * @suppress {unusedLocalVariables} f is only used for nested messages
 */
proto.chatMessageResponse.user.toObject = function(includeInstance, msg) {
  var f, obj = {
    connectionId: jspb.Message.getFieldWithDefault(msg, 1, ""),
    name: jspb.Message.getFieldWithDefault(msg, 2, "")
  };

  if (includeInstance) {
    obj.$jspbMessageInstance = msg;
  }
  return obj;
};
}


/**
 * Deserializes binary data (in protobuf wire format).
 * @param {jspb.ByteSource} bytes The bytes to deserialize.
 * @return {!proto.chatMessageResponse.user}
 */
proto.chatMessageResponse.user.deserializeBinary = function(bytes) {
  var reader = new jspb.BinaryReader(bytes);
  var msg = new proto.chatMessageResponse.user;
  return proto.chatMessageResponse.user.deserializeBinaryFromReader(msg, reader);
};


/**
 * Deserializes binary data (in protobuf wire format) from the
 * given reader into the given message object.
 * @param {!proto.chatMessageResponse.user} msg The message object to deserialize into.
 * @param {!jspb.BinaryReader} reader The BinaryReader to use.
 * @return {!proto.chatMessageResponse.user}
 */
proto.chatMessageResponse.user.deserializeBinaryFromReader = function(msg, reader) {
  while (reader.nextField()) {
    if (reader.isEndGroup()) {
      break;
    }
    var field = reader.getFieldNumber();
    switch (field) {
    case 1:
      var value = /** @type {string} */ (reader.readString());
      msg.setConnectionId(value);
      break;
    case 2:
      var value = /** @type {string} */ (reader.readString());
      msg.setName(value);
      break;
    default:
      reader.skipField();
      break;
    }
  }
  return msg;
};


/**
 * Serializes the message to binary data (in protobuf wire format).
 * @return {!Uint8Array}
 */
proto.chatMessageResponse.user.prototype.serializeBinary = function() {
  var writer = new jspb.BinaryWriter();
  proto.chatMessageResponse.user.serializeBinaryToWriter(this, writer);
  return writer.getResultBuffer();
};


/**
 * Serializes the given message to binary data (in protobuf wire
 * format), writing to the given BinaryWriter.
 * @param {!proto.chatMessageResponse.user} message
 * @param {!jspb.BinaryWriter} writer
 * @suppress {unusedLocalVariables} f is only used for nested messages
 */
proto.chatMessageResponse.user.serializeBinaryToWriter = function(message, writer) {
  var f = undefined;
  f = message.getConnectionId();
  if (f.length > 0) {
    writer.writeString(
      1,
      f
    );
  }
  f = message.getName();
  if (f.length > 0) {
    writer.writeString(
      2,
      f
    );
  }
};


/**
 * optional string connection_id = 1;
 * @return {string}
 */
proto.chatMessageResponse.user.prototype.getConnectionId = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 1, ""));
};


/**
 * @param {string} value
 * @return {!proto.chatMessageResponse.user} returns this
 */
proto.chatMessageResponse.user.prototype.setConnectionId = function(value) {
  return jspb.Message.setProto3StringField(this, 1, value);
};


/**
 * optional string name = 2;
 * @return {string}
 */
proto.chatMessageResponse.user.prototype.getName = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 2, ""));
};


/**
 * @param {string} value
 * @return {!proto.chatMessageResponse.user} returns this
 */
proto.chatMessageResponse.user.prototype.setName = function(value) {
  return jspb.Message.setProto3StringField(this, 2, value);
};


/**
 * optional messageTypes msgType = 1;
 * @return {!proto.messageTypes}
 */
proto.chatMessageResponse.prototype.getMsgtype = function() {
  return /** @type {!proto.messageTypes} */ (jspb.Message.getFieldWithDefault(this, 1, 0));
};


/**
 * @param {!proto.messageTypes} value
 * @return {!proto.chatMessageResponse} returns this
 */
proto.chatMessageResponse.prototype.setMsgtype = function(value) {
  return jspb.Message.setProto3EnumField(this, 1, value);
};


/**
 * optional string message = 2;
 * @return {string}
 */
proto.chatMessageResponse.prototype.getMessage = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 2, ""));
};


/**
 * @param {string} value
 * @return {!proto.chatMessageResponse} returns this
 */
proto.chatMessageResponse.prototype.setMessage = function(value) {
  return jspb.Message.setProto3StringField(this, 2, value);
};


/**
 * optional int32 cnt = 3;
 * @return {number}
 */
proto.chatMessageResponse.prototype.getCnt = function() {
  return /** @type {number} */ (jspb.Message.getFieldWithDefault(this, 3, 0));
};


/**
 * @param {number} value
 * @return {!proto.chatMessageResponse} returns this
 */
proto.chatMessageResponse.prototype.setCnt = function(value) {
  return jspb.Message.setProto3IntField(this, 3, value);
};


/**
 * repeated user users = 4;
 * @return {!Array<!proto.chatMessageResponse.user>}
 */
proto.chatMessageResponse.prototype.getUsersList = function() {
  return /** @type{!Array<!proto.chatMessageResponse.user>} */ (
    jspb.Message.getRepeatedWrapperField(this, proto.chatMessageResponse.user, 4));
};


/**
 * @param {!Array<!proto.chatMessageResponse.user>} value
 * @return {!proto.chatMessageResponse} returns this
*/
proto.chatMessageResponse.prototype.setUsersList = function(value) {
  return jspb.Message.setRepeatedWrapperField(this, 4, value);
};


/**
 * @param {!proto.chatMessageResponse.user=} opt_value
 * @param {number=} opt_index
 * @return {!proto.chatMessageResponse.user}
 */
proto.chatMessageResponse.prototype.addUsers = function(opt_value, opt_index) {
  return jspb.Message.addToRepeatedWrapperField(this, 4, opt_value, proto.chatMessageResponse.user, opt_index);
};


/**
 * Clears the list making it empty but non-null.
 * @return {!proto.chatMessageResponse} returns this
 */
proto.chatMessageResponse.prototype.clearUsersList = function() {
  return this.setUsersList([]);
};


/**
 * optional string selfconnetionId = 5;
 * @return {string}
 */
proto.chatMessageResponse.prototype.getSelfconnetionid = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 5, ""));
};


/**
 * @param {string} value
 * @return {!proto.chatMessageResponse} returns this
 */
proto.chatMessageResponse.prototype.setSelfconnetionid = function(value) {
  return jspb.Message.setProto3StringField(this, 5, value);
};



/**
 * List of repeated fields within this message type.
 * @private {!Array<number>}
 * @const
 */
proto.chatMessageRequest.repeatedFields_ = [5];



if (jspb.Message.GENERATE_TO_OBJECT) {
/**
 * Creates an object representation of this proto.
 * Field names that are reserved in JavaScript and will be renamed to pb_name.
 * Optional fields that are not set will be set to undefined.
 * To access a reserved field use, foo.pb_<name>, eg, foo.pb_default.
 * For the list of reserved names please see:
 *     net/proto2/compiler/js/internal/generator.cc#kKeyword.
 * @param {boolean=} opt_includeInstance Deprecated. whether to include the
 *     JSPB instance for transitional soy proto support:
 *     http://goto/soy-param-migration
 * @return {!Object}
 */
proto.chatMessageRequest.prototype.toObject = function(opt_includeInstance) {
  return proto.chatMessageRequest.toObject(opt_includeInstance, this);
};


/**
 * Static version of the {@see toObject} method.
 * @param {boolean|undefined} includeInstance Deprecated. Whether to include
 *     the JSPB instance for transitional soy proto support:
 *     http://goto/soy-param-migration
 * @param {!proto.chatMessageRequest} msg The msg instance to transform.
 * @return {!Object}
 * @suppress {unusedLocalVariables} f is only used for nested messages
 */
proto.chatMessageRequest.toObject = function(includeInstance, msg) {
  var f, obj = {
    message: jspb.Message.getFieldWithDefault(msg, 1, ""),
    touser: jspb.Message.getFieldWithDefault(msg, 2, ""),
    user: jspb.Message.getFieldWithDefault(msg, 3, ""),
    cnt: jspb.Message.getFieldWithDefault(msg, 4, 0),
    usersList: (f = jspb.Message.getRepeatedField(msg, 5)) == null ? undefined : f,
    msgtype: jspb.Message.getFieldWithDefault(msg, 6, 0),
    selfconnetionid: jspb.Message.getFieldWithDefault(msg, 7, ""),
    otherconnetionid: jspb.Message.getFieldWithDefault(msg, 8, "")
  };

  if (includeInstance) {
    obj.$jspbMessageInstance = msg;
  }
  return obj;
};
}


/**
 * Deserializes binary data (in protobuf wire format).
 * @param {jspb.ByteSource} bytes The bytes to deserialize.
 * @return {!proto.chatMessageRequest}
 */
proto.chatMessageRequest.deserializeBinary = function(bytes) {
  var reader = new jspb.BinaryReader(bytes);
  var msg = new proto.chatMessageRequest;
  return proto.chatMessageRequest.deserializeBinaryFromReader(msg, reader);
};


/**
 * Deserializes binary data (in protobuf wire format) from the
 * given reader into the given message object.
 * @param {!proto.chatMessageRequest} msg The message object to deserialize into.
 * @param {!jspb.BinaryReader} reader The BinaryReader to use.
 * @return {!proto.chatMessageRequest}
 */
proto.chatMessageRequest.deserializeBinaryFromReader = function(msg, reader) {
  while (reader.nextField()) {
    if (reader.isEndGroup()) {
      break;
    }
    var field = reader.getFieldNumber();
    switch (field) {
    case 1:
      var value = /** @type {string} */ (reader.readString());
      msg.setMessage(value);
      break;
    case 2:
      var value = /** @type {string} */ (reader.readString());
      msg.setTouser(value);
      break;
    case 3:
      var value = /** @type {string} */ (reader.readString());
      msg.setUser(value);
      break;
    case 4:
      var value = /** @type {number} */ (reader.readInt32());
      msg.setCnt(value);
      break;
    case 5:
      var value = /** @type {string} */ (reader.readString());
      msg.addUsers(value);
      break;
    case 6:
      var value = /** @type {!proto.messageTypes} */ (reader.readEnum());
      msg.setMsgtype(value);
      break;
    case 7:
      var value = /** @type {string} */ (reader.readString());
      msg.setSelfconnetionid(value);
      break;
    case 8:
      var value = /** @type {string} */ (reader.readString());
      msg.setOtherconnetionid(value);
      break;
    default:
      reader.skipField();
      break;
    }
  }
  return msg;
};


/**
 * Serializes the message to binary data (in protobuf wire format).
 * @return {!Uint8Array}
 */
proto.chatMessageRequest.prototype.serializeBinary = function() {
  var writer = new jspb.BinaryWriter();
  proto.chatMessageRequest.serializeBinaryToWriter(this, writer);
  return writer.getResultBuffer();
};


/**
 * Serializes the given message to binary data (in protobuf wire
 * format), writing to the given BinaryWriter.
 * @param {!proto.chatMessageRequest} message
 * @param {!jspb.BinaryWriter} writer
 * @suppress {unusedLocalVariables} f is only used for nested messages
 */
proto.chatMessageRequest.serializeBinaryToWriter = function(message, writer) {
  var f = undefined;
  f = message.getMessage();
  if (f.length > 0) {
    writer.writeString(
      1,
      f
    );
  }
  f = message.getTouser();
  if (f.length > 0) {
    writer.writeString(
      2,
      f
    );
  }
  f = message.getUser();
  if (f.length > 0) {
    writer.writeString(
      3,
      f
    );
  }
  f = message.getCnt();
  if (f !== 0) {
    writer.writeInt32(
      4,
      f
    );
  }
  f = message.getUsersList();
  if (f.length > 0) {
    writer.writeRepeatedString(
      5,
      f
    );
  }
  f = message.getMsgtype();
  if (f !== 0.0) {
    writer.writeEnum(
      6,
      f
    );
  }
  f = message.getSelfconnetionid();
  if (f.length > 0) {
    writer.writeString(
      7,
      f
    );
  }
  f = message.getOtherconnetionid();
  if (f.length > 0) {
    writer.writeString(
      8,
      f
    );
  }
};


/**
 * optional string message = 1;
 * @return {string}
 */
proto.chatMessageRequest.prototype.getMessage = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 1, ""));
};


/**
 * @param {string} value
 * @return {!proto.chatMessageRequest} returns this
 */
proto.chatMessageRequest.prototype.setMessage = function(value) {
  return jspb.Message.setProto3StringField(this, 1, value);
};


/**
 * optional string touser = 2;
 * @return {string}
 */
proto.chatMessageRequest.prototype.getTouser = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 2, ""));
};


/**
 * @param {string} value
 * @return {!proto.chatMessageRequest} returns this
 */
proto.chatMessageRequest.prototype.setTouser = function(value) {
  return jspb.Message.setProto3StringField(this, 2, value);
};


/**
 * optional string user = 3;
 * @return {string}
 */
proto.chatMessageRequest.prototype.getUser = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 3, ""));
};


/**
 * @param {string} value
 * @return {!proto.chatMessageRequest} returns this
 */
proto.chatMessageRequest.prototype.setUser = function(value) {
  return jspb.Message.setProto3StringField(this, 3, value);
};


/**
 * optional int32 cnt = 4;
 * @return {number}
 */
proto.chatMessageRequest.prototype.getCnt = function() {
  return /** @type {number} */ (jspb.Message.getFieldWithDefault(this, 4, 0));
};


/**
 * @param {number} value
 * @return {!proto.chatMessageRequest} returns this
 */
proto.chatMessageRequest.prototype.setCnt = function(value) {
  return jspb.Message.setProto3IntField(this, 4, value);
};


/**
 * repeated string users = 5;
 * @return {!Array<string>}
 */
proto.chatMessageRequest.prototype.getUsersList = function() {
  return /** @type {!Array<string>} */ (jspb.Message.getRepeatedField(this, 5));
};


/**
 * @param {!Array<string>} value
 * @return {!proto.chatMessageRequest} returns this
 */
proto.chatMessageRequest.prototype.setUsersList = function(value) {
  return jspb.Message.setField(this, 5, value || []);
};


/**
 * @param {string} value
 * @param {number=} opt_index
 * @return {!proto.chatMessageRequest} returns this
 */
proto.chatMessageRequest.prototype.addUsers = function(value, opt_index) {
  return jspb.Message.addToRepeatedField(this, 5, value, opt_index);
};


/**
 * Clears the list making it empty but non-null.
 * @return {!proto.chatMessageRequest} returns this
 */
proto.chatMessageRequest.prototype.clearUsersList = function() {
  return this.setUsersList([]);
};


/**
 * optional messageTypes msgType = 6;
 * @return {!proto.messageTypes}
 */
proto.chatMessageRequest.prototype.getMsgtype = function() {
  return /** @type {!proto.messageTypes} */ (jspb.Message.getFieldWithDefault(this, 6, 0));
};


/**
 * @param {!proto.messageTypes} value
 * @return {!proto.chatMessageRequest} returns this
 */
proto.chatMessageRequest.prototype.setMsgtype = function(value) {
  return jspb.Message.setProto3EnumField(this, 6, value);
};


/**
 * optional string selfconnetionId = 7;
 * @return {string}
 */
proto.chatMessageRequest.prototype.getSelfconnetionid = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 7, ""));
};


/**
 * @param {string} value
 * @return {!proto.chatMessageRequest} returns this
 */
proto.chatMessageRequest.prototype.setSelfconnetionid = function(value) {
  return jspb.Message.setProto3StringField(this, 7, value);
};


/**
 * optional string otherconnetionId = 8;
 * @return {string}
 */
proto.chatMessageRequest.prototype.getOtherconnetionid = function() {
  return /** @type {string} */ (jspb.Message.getFieldWithDefault(this, 8, ""));
};


/**
 * @param {string} value
 * @return {!proto.chatMessageRequest} returns this
 */
proto.chatMessageRequest.prototype.setOtherconnetionid = function(value) {
  return jspb.Message.setProto3StringField(this, 8, value);
};


/**
 * @enum {number}
 */
proto.messageTypes = {
  GETONLINEUSERS: 0,
  ALL: 1,
  PERSON: 2
};

goog.object.extend(exports, proto);