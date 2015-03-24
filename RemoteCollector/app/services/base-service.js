var ObjectId = require("mongodb").ObjectID;
var moment = require("moment");
var _ = require("underscore");
var userDataRepository = require("../repositories/user-data-repository");

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

BaseService.prototype.updateBaseFields = function (object, userId) {
  if(_.isEmpty(object.createdBy)){
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

module.exports = BaseService;