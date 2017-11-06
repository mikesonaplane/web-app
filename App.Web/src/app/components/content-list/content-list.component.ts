import { Component, OnInit } from '@angular/core';

import { ContentService } from '../../services/content.service';

import { environment } from "../../../environments/environment";

@Component({
  selector: 'app-content-list',
  templateUrl: './content-list.component.html',
  styleUrls: ['./content-list.component.css']
})
export class ContentListComponent implements OnInit {

  constructor(
    private contentService: ContentService
  ) { }

  ngOnInit() {

  }

}
