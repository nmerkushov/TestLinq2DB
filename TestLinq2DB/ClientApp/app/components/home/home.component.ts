import { Component, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import { TestItem } from '../models/testItem'
import { CommonService } from '../services/common.service'

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
	@ViewChild('testListGrid') testListGrid: DxDataGridComponent;
	testList: TestItem[] = new Array<TestItem>();

	constructor(private service: CommonService) {
		this.fillDatasource();
	}

	fillDatasource() {
		this.service.getTests()
			.then(res => {
				this.testList = res;
			})
			.catch(error => console.error(error));
	}
}
