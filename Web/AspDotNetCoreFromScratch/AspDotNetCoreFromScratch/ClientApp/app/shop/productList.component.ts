import { Component } from "@angular/core"

@Component({
	selector: "product-list",
	templateUrl: "./productList.component.html",
	styleUrls: []
})
export class ProductList {
	public products = [{
		title: "1st Product",
		price: 23.56
	},{
		title: "2nd Product",
		price: 39.21
	}, {
		title: "3rd Product",
		price: 5.99
	}]
}