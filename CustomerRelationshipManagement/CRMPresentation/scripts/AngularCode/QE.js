var app = angular.module('qapp', []);
app.controller('MainCtrl', function ($scope, $http, $timeout) {

    $("#custDetails").show();

    //Product Line Items Details
    $scope.rowsNew = [
        {
            "item_code": 1001,
            "quantity": 4,
            "uom": "Nos.",
            "product_mrp": 55,
            "product_discount": 20,
            "amount": 450
        },
         {
             "item_code": 1002,
             "quantity": 5,
             "uom": "Nos.",
             "product_mrp": 70,
             "product_discount": 5,
             "amount": 650
         }

    ];

    //Load Quote Details

    var qDetails = {
        "PrimaryMailID": "JD@gmail.com",
        "PrimaryPhoneNo": "90944326423",
        "ContactPersonName": "Ram",
        "ContactPersonNo": "90944326423",
        "BillingAddress": "Parvathy Nagar",
        "BillingAddress1": "Parvathy Nagar",
        "BillingCity": "Chennai",
        "BillingState": "Tamilandu",
        "BillingCountry": "India",
        "BillingPincode": "600063",
        "ShippingAddress": "Parvathy Nagar",
        "ShippingAddress1": "Parvathy Nagar",
        "ShippingCity": "Chennai",
        "ShippingState": "Tamilandu",
        "ShippingCountry": "India",
        "ShippingPincode": "600063",
        "TotalAmount": 1700,
    };


    //Assign Values to the Fields from Loaded data
    $scope.PrimaryMail = qDetails.PrimaryMailID;
    $scope.PrimayPhone = qDetails.PrimaryPhoneNo;
    $scope.PersonName = qDetails.ContactPersonName;
    $scope.PersonNo = qDetails.ContactPersonNo;
    $scope.BillingAddress = qDetails.BillingAddress;
    $scope.BillingAddress1 = qDetails.BillingAddress1;
    $scope.BillingCity = qDetails.BillingCity;
    $scope.BillingState = qDetails.BillingState;
    $scope.BillingCountry = qDetails.BillingCountry;
    $scope.BillingPincode = qDetails.BillingPincode;
    $scope.ShippingAddress = qDetails.ShippingAddress;
    $scope.ShippingAddress1 = qDetails.ShippingAddress1;
    $scope.ShippingCity = qDetails.ShippingCity;
    $scope.ShippingState = qDetails.ShippingState;
    $scope.ShippingCountry = qDetails.ShippingCountry;
    $scope.ShippingPincode = qDetails.ShippingPincode;
    $scope.total = qDetails.TotalAmount;



    //Load Data to Customer DropdownList
    $scope.GetData = function () {
        $http({
            method: 'GET',
            url: '/Customer/GetCustomerList'
        }).
          then(function (response) {
              $scope.customeDetails = response.data;
          }, function () {
              alert("Error Occur");
          })
    };

    //TO DO :-Needs to load data from server
    $scope.options = [{ CustomerName: 'Just Dial', CustomerID: 4 }, { CustomerName: 'New India Test', CustomerID: 5 }];
    $scope.cust = $scope.options[0].CustomerID;


    //Sample Product Details
    $scope.product = [
         {
             "item_code": 1001,
             "uom": "Nos.",
             "product_mrp": 12,
             "item_description": "CHOCO FILL 250GM"
         },
         {
             "item_code": 1002,
             "uom": "Nos.",
             "product_mrp": 38,
             "item_description": "LUX GOLD 75GM"
         },
         {
             "item_code": 1003,
             "uom": "Nos.",
             "product_mrp": 20,
             "item_description": "CHOCO BAR"
         },
         {
             "item_code": 1004,
             "uom": "Nos.",
             "product_mrp": 15,
             "item_description": "CASATA"
         },
         {
             "item_code": 1005,
             "uom": "Nos.",
             "product_mrp": 12,
             "item_description": "GOOD DAY 100GM"
         },
         {
             "item_code": 1006,
             "uom": "Nos.",
             "product_mrp": 18,
             "item_description": "Garam Masala"
         },
         {
             "item_code": 1007,
             "uom": "Nos.",
             "product_mrp": 25,
             "item_description": "VIVEL SOFT 75GM"
         },
         {
             "item_code": 1008,
             "uom": "Nos.",
             "product_mrp": 45,
             "item_description": "SUNLIGHT 500GM"
         },
         {
             "item_code": 1009,
             "uom": "Nos.",
             "product_mrp": 65,
             "item_description": "Dove 75gm"
         },
         {
             "item_code": 1010,
             "uom": "Nos.",
             "product_mrp": 38,
             "item_description": "NIRMA 250GM"
         },
         {
             "item_code": 1011,
             "uom": "Nos.",
             "product_mrp": 150,
             "item_description": "FOUNDATION CREAM"
         }]

    //Calculate Total Amount
    $scope.total_amount = function () {
        var total = 0;
        $scope.rowsNew.forEach(function (row) {
            total += row.amount;
        });
        $scope.total = total;
        return total;
    };
    //Add New rows to table
    $scope.rows = [{}];
    $scope.addRow = function () {
        $scope.rowsNew.push({
        });
        $scope.total_amount();
    };

    //Remove rows from table
    $scope.remove = function (index) {
        if ($scope.rowsNew.length > 1)
            $scope.rowsNew.splice(index, 1);
        else
            alert("One Line is required");
    };
    //Get Product Details on Product Dropdown change
    $scope.getProductDetails = function (row) {
        angular.forEach($scope.product, function (p) {
            if (p.item_code == row.item_code) {
                row.uom = p.uom;
                row.product_mrp = p.product_mrp;
            }
        })
    }


});