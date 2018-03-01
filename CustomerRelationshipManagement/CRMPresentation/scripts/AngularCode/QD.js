
var app = angular.module('qapp', []);

app.controller('MainCtrl', function ($scope, $http, $timeout) {

    $("#custDetails").hide();

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

    //Get Customer Details on Dropdown Change
    $scope.GetCustomerDetails = function () {
        $("#custDetails").hide();

        if ($scope.cust) {
            $("#custDetails").show();

            $http({
                method: 'POST',
                url: '/Customer/GetCustDetails/',
                data: JSON.stringify({ CustomerID: $scope.cust })
            }).
                   then(function (response) {
                       $scope.PrimaryMail = response.data.PrimaryMailID;
                       $scope.PrimayPhone = response.data.PrimaryPhoneNo;
                       $scope.PersonName = response.data.ContactPersonName;
                       $scope.PersonNo = response.data.ContactPersonNo;

                       $scope.BillingAddress = response.data.BillingAddress;
                       $scope.BillingAddress1 = response.data.BillingAddress1;
                       $scope.BillingCity = response.data.BillingCity;
                       $scope.BillingState = response.data.BillingState;
                       $scope.BillingCountry = response.data.BillingCountry;
                       $scope.BillingPincode = response.data.BillingPincode;

                       $scope.ShippingAddress = response.data.ShippingAddress;
                       $scope.ShippingAddress1 = response.data.ShippingAddress1;
                       $scope.ShippingCity = response.data.ShippingCity;
                       $scope.ShippingState = response.data.ShippingState;
                       $scope.ShippingCountry = response.data.ShippingCountry;
                       $scope.ShippingPincode = response.data.ShippingPincode;

                   });
        }
    };

    //Add New rows to table
    $scope.rows = [{}];
    $scope.addRow = function () {
        $scope.rows.push({
        });
        $scope.total_amount();
    };

    //Remove rows from table
    $scope.remove = function (index) {
        if ($scope.rows.length > 1)
            $scope.rows.splice(index, 1);
        else
            alert("One Line is required");
    };

    //Get Product Details on Product Dropdown change
    $scope.getProductDetails = function (row, index) {

        if ($scope.rows.length > 1) {
            var i = 0;
            angular.forEach($scope.rows, function (selected) {
                // debugger;
                if (selected.item_code == row.item_code && i != index) {
                    $scope.rows.splice(index, 1);
                    alert("Item already selected.Please Select another Item.");
                }
                i = i + 1;
            });
        }


        angular.forEach($scope.product, function (p) {
            if (p.item_code == row.item_code) {
                row.uom = p.uom;
                row.product_mrp = p.product_mrp;

            }
        })

    }

    //Calculate Total Amount
    $scope.total_amount = function () {
        var total = 0;
        $scope.rows.forEach(function (row) {
            total += row.amount;
        });
        $scope.total = total;
        return total;
    };

    //Discount Calculation 
    $scope.calDiscount = function (index) {
        //var amount = $scope.rows[index].amount;
        //var discount = $scope.rows[index].product_discount;
        //var discountedamount = parseInt(amount) - parseInt(discount);
        //alert(discountedamount);

        //$scope.rows[index].amount = discountedamount;
    };


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


    //Create a New Quote
    $scope.create = function () {
        $scope.QuoteDetails = {};
        $scope.QuoteDetails.CustomerID = $scope.cust;
        $scope.QuoteDetails.PrimaryMailID = $scope.PrimaryMail;
        $scope.QuoteDetails.PrimaryPhoneNo = $scope.PrimayPhone;
        $scope.QuoteDetails.ContactPersonName = $scope.PersonName;
        $scope.QuoteDetails.ContactPersonNo = $scope.PersonNo;
        $scope.QuoteDetails.BillingAddress = $scope.BillingAddress;
        $scope.QuoteDetails.BillingAddress1 = $scope.BillingAddress1;
        $scope.QuoteDetails.BillingCity = $scope.BillingCity;
        $scope.QuoteDetails.BillingState = $scope.BillingState;
        $scope.QuoteDetails.BillingCountry = $scope.BillingCountry;
        $scope.QuoteDetails.BillingPincode = $scope.BillingPincode;
        $scope.QuoteDetails.ShippingAddress = $scope.ShippingAddress;
        $scope.QuoteDetails.ShippingAddress1 = $scope.ShippingAddress1;
        $scope.QuoteDetails.ShippingCity = $scope.ShippingCity;
        $scope.QuoteDetails.ShippingState = $scope.ShippingState;
        $scope.QuoteDetails.ShippingCountry = $scope.ShippingCountry;
        $scope.QuoteDetails.ShippingPincode = $scope.ShippingPincode;
        $scope.QuoteDetails.TotalAmount = $scope.total;

        //Product Items Detail
        $scope.QuoteItems = [];
        $scope.items = {};
        angular.forEach($scope.rows, function (quoteDetail) {
            $scope.items.ProductID = quoteDetail.item_code;
            $scope.items.Quantity = quoteDetail.quantity;
            $scope.items.UOM = quoteDetail.uom;
            $scope.items.MRP = quoteDetail.product_mrp;
            $scope.items.Discount = quoteDetail.product_discount;
            $scope.items.ItemTotal = quoteDetail.amount;
            $scope.QuoteItems.push($scope.items);
        });
        $scope.QuoteDetails.QuoteItemsList = $scope.QuoteItems;

        $http({
            method: "post",
            url: "http://localhost:50480/Quote/SaveQuote",
            datatype: "json",
            data: JSON.stringify($scope.QuoteDetails)
        }).then(function (response) {
            alert(response.data);

        })
    };
});