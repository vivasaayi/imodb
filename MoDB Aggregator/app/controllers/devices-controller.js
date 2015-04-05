"use strict";

var util = require('util');
var DeviceService = require("../services/devices-service");
var BaseController = require("./base-controller");
var underscore = require("underscore");

var deviceService = new DeviceService();

var DevicesController = function () {
};

util.inherits(DevicesController, BaseController);

DevicesController.prototype.getAllDevices = function (req, res) {
  
  deviceService.getAllDevices(function (err, result) {
    if (err) {
      res.send({ error: "error", message: err });
    } else {
      res.send({ status: "Success", result: result });
    }
  });
};

module.exports = DevicesController;