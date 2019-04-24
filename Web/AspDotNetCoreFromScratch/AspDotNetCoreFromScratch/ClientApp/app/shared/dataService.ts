import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Product } from './product';

// This class will contain all the data that is shared between the different components:
@Injectable()
export class DataService {
	constructor(private http: HttpClient) { }

	public products : Product[] = [];

	loadProducts(): Observable<boolean> {
		return this.http.get("/api/products")			// returns an observable that clients can subscribe to to be notified on changes
			.pipe(
			map((data: any[]) => {
				this.products = data;
				return true;
			})
			);
	}
}