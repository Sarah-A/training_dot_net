import { Component } from "@angular/core";
import { DataService } from '../shared/dataService';
import { Router } from '@angular/router';

@Component({
	selector: "checkout",
  templateUrl: "checkout.component.html",
  styleUrls: ['checkout.component.css']
})
export class Checkout {

	errorMessage: string = "";

	constructor(private data: DataService, private router: Router) { }

	onCheckout() {
		this.data.checkout()
			.subscribe(success => {
				if (success) {
					alert("Order Completed Successfully");
					this.router.navigate([""]);
				}
			}, err => this.errorMessage = "Failed to save order");

	}
}