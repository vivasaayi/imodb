var pg = require("pg");
var async = require("async");

var connectionString = "";
var database = undefined;

module.exports.startDatabase = function (dbConfig, callback) {
  connectionString = "postgres://" + dbConfig.userName + ":" + dbConfig.password + "@" + dbConfig.host + ":" + dbConfig.port + "/" + dbConfig.databaseName;
  
  pg.connect(connectionString, function (err, client, done) {
    done(client);
    if (err) {
      callback(err, null);
    } else {
      callback(null, client);
    }
  });
};


var createDocument = function (query, data, callback) {
  
  pg.connect(connectionString, function (err, client, done) {
    if (err) {
      done(client);
      callback(err, null);
    } else {
      client.query(query, data, function (err, result) {
        if (err) {
          done(client);
          callback(err, null);
        } else {
          done();
          callback(null, result);
        }     
      });
    }
  });
};

module.exports.executeSelectQuery = function (query, callback) {
  pg.connect(connectionString, function (err, client, done) {
    if (err) {
      done(client);
      callback(err, null);
    } else {
      client.query(query, function (err, result) {
        if (err) {
          done(client);
          callback(err, null);
        } else {
          done();
          callback(null, result.rows);
        }
      });
    }
  });
};

module.exports.createDocuments = function (query, data, completedCallback) {
  var createFunction = function (currentRecord, iteratorCallback) {
    console.log("Creating document:" + currentRecord[0]);
    
    createDocument(query, currentRecord, function (err) {
      if (err) {
        iteratorCallback(err);
      } else {
        iteratorCallback();
      }
    });
  }
  
  var finalCallback = function (err) {
    console.log("Completed creating documents");
    completedCallback(err);
  }
  
  async.eachSeries(data, createFunction, finalCallback)
};