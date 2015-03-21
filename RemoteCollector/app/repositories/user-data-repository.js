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