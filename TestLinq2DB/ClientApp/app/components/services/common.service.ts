import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/Rx';
import { TestItem } from '../models/testItem';

@Injectable()
export class CommonService {
	constructor(private http: Http) {
	}

	getTests() {
		return this.http.get('/home/gettests')
			.map((response: Response) => {
				return response.json() as TestItem[];
			})
			.toPromise();
	}
}