var app = angular.module("myApp", []);

app.controller("myCtrl", function ($scope, $http, $window) {
    $('#inputPID').hide();


    //Get All Product 

    $scope.GetAllData = function () {
        $http({
            method: "get",
            url: "http://localhost:50480/Product/GetProductList"
        }).then(function (response) {
            $scope.products = response.data;
        }, function () {
            alert("Error Occur");
        })
    };

    //Delete Product by ID

    $scope.DeleteProd = function (Prod) {
        if ($window.confirm("Do you want to delete this row?")) {
            $http({
                method: "post",
                url: "http://localhost:50480/Product/DeleteProduct",
                datatype: "json",
                data: JSON.stringify(Prod)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
            })
        }
    };

    //Insert New Product
    $scope.InsertProd = function () {
        $scope.Product = {};
        $scope.Product.ProdName = $scope.ProdName;
        $scope.Product.ProdDesc = $scope.ProdDescription;
        $scope.Product.Status = $scope.ProdStatus;
        $http({
            method: "post",
            url: "http://localhost:50480/Product/NewProduct",
            datatype: "json",
            data: JSON.stringify($scope.Product)
        }).then(function (response) {
            alert(response.data);
            $scope.GetAllData();
            $scope.ProdName = "";
            $scope.ProdDescription = "";
            $scope.ProdStatus = "";
        })
    };

    //Update Product

    $scope.UpdateProd = function (prod) {
        document.getElementById("editProd").style.display = "";
        $scope.PName = prod.ProdName;
        $scope.PDescription = prod.ProdDesc;
        $scope.PStatus = prod.Status;
        $scope.PID = prod.ProdID;
    };

    $scope.UpdateProduct = function () {
        $scope.Product = {};
        $scope.Product.ProdName = $scope.PName;
        $scope.Product.ProdDesc = $scope.PDescription;
        $scope.Product.Status = $scope.PStatus;
        $scope.Product.ProdID = $scope.PID;

        $http({
            method: "post",
            url: "http://localhost:50480/Product/UpdateProduct",
            datatype: "json",
            data: JSON.stringify($scope.Product)
        }).then(function (response) {
            alert(response.data);
            $scope.GetAllData();
            $scope.PName = "";
            $scope.PDescription = "";
            $scope.PStatus = "";
            document.getElementById("editProd").style.display = "none";
        })
    };


    //Search Product
    $scope.FilterProuct = function () {
        if (typeof ($scope.SName) == "undefined" || typeof ($scope.SDescription) == "undefined" || typeof ($scope.SStatus) == "undefined") {
            alert("Please Enter Filter Values !");
            return;
        }
        $scope.Product = {};
        $scope.Product.ProdName = $scope.SName;
        $scope.Product.ProdDesc = $scope.SDescription;
        $scope.Product.Status = $scope.SStatus;

        $http({
            method: "post",
            url: "http://localhost:50480/Product/SearchProduct",
            datatype: "json",
            data: JSON.stringify($scope.Product)
        }).then(function (response) {
            $scope.products = response.data;
            $scope.SName = "";
            $scope.SDescription = "";
            $scope.SStatus = "";
            

        })
    };

});