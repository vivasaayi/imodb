var ObjectId = require("mongodb").ObjectID;
var moment = require("moment");
var _ = require("underscore");
var userDataRepository = require("../repositories/user-data-repository");
var async = require("async");

var BaseService = function () {

};

BaseService.prototype.invokeCallBack = function (callback, err, response) {
  if (err) {
    callback(err, null);
  } else {
    callback(null, response);
  }
};

BaseService.prototype.saveDocument = function (collection, document, userId, callback) {
  this.updateBaseFields(document, userId);
  userDataRepository.save(collection, document, _.partial(this.invokeCallBack, callback));
};

BaseService.prototype.createDocuments = function (query, data, callback) {
  userDataRepository.createDocuments(query, data, callback);
};

BaseService.prototype.updateBaseFields = function (object, userId) {
  if (_.isEmpty(object.createdBy)) {
    object.createdBy = userId;
    object.createdOn = moment().valueOf();
  }
  object.updatedBy = userId;
  object.updatedOn = moment().valueOf();
};

BaseService.prototype.getRecentFromCollection = function (collection, callback) {
  userDataRepository.loadWithLimit(collection, 5, _.partial(this.invokeCallBack, callback));
};

BaseService.prototype.deleteDocument = function (collection, document, callback) {
  userDataRepository.delete(collection, document, callback);
};

BaseService.prototype.deleteDocuments = function (collection, ids, completedCallback) {
  var deleteFunction = function (id, iteratorCallback) {
    console.log("Deleting document:" + id);
    var doc = {
      _id: id
    };
    userDataRepository.delete(collection, doc, function (err) {
      if (err) {
        iteratorCallback(err);
      } else {
        iteratorCallback();
      }
    });
  }
  
  var finalCallback = function (err) {
    console.log("Completed deleting documents");
    completedCallback(err);
  }
  
  async.eachSeries(ids, deleteFunction, finalCallback)
}

module.exports = BaseService;