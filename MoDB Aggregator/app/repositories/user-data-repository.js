"use strict";

var database = require("dal");
var objectId = require("mongodb").ObjectID;

module.exports.save = function (collectionName, document, callback) {
  console.log("Saving: " + collectionName);

  if (document._id) {
    database.updateDocument(collectionName, document, function (err, result) {
      callback(err, result);
    });
  } else {
    database.insertDocument(collectionName, document, function (err, result) {
      callback(err, result);
    });
  }
};


module.exports.loadWithLimit = function (collectionName, limit, callback) {
  console.log("Loading " + collectionName);

  database.getTopXFromCollection(collectionName, limit, function (err, result) {
    callback(err, result);
  });
};


module.exports.delete = function (collectionName, document, callback) {
  console.log("Deleting");
  
  if (document._id) {
    database.deleteDocument(collectionName, document, function (err, result) {
      callback(err, result);
    });
  }
};