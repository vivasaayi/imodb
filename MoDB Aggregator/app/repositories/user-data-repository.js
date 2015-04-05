"use strict";

var database = require("./database-heler.js");
var objectId = require("mongodb").ObjectID;

module.exports.createDocuments = function(query, data, callback) {
  database.createDocuments(query, data, callback);
};

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