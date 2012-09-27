(function() {
  var User, UserList;

  User = function() {
    var UserName;
    return UserName = ko.observable(data.UserName);
  };

  ({
    UserName: UserName
  });

  UserList = function() {
    var MapData, cancel, load, users;
    users = ko.observableArray([]);
    MapData = function(allData) {
      var mappedItems;
      mappedItems = $.map(allData, function(item) {
        return User(item);
      });
      return users(mappedItems);
    };
    load = function() {
      return $.getJSON("/Admin/Users/GetUsers", function(allData) {
        return MapData(allData);
      });
    };
    cancel = function() {
      return load;
    };
    return {
      users: users
    };
  };

}).call(this);
