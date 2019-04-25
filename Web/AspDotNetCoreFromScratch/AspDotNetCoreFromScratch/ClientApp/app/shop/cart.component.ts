import { Component } from '@angular/core';
import { DataService } from '../shared/dataService';
import { Router } from '@angular/router';

@Component({
	selector: "cart",
	templateUrl: "./cart.component.html",
	styleUrls: []
})
export class Cart {
	constructor(private data: DataService, private router: Router) { }

	onCheckout() {
		if (this.data.loginRequired) {
			// force login
			this.router.navigate(["login"]);
		} else {
			this.router.navigate(["checkout"]);
		}

	}
}
