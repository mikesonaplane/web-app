import { Component, OnInit } from '@angular/core';

import { Content } from '../../interfaces/content';
import { ContentService } from '../../services/content.service';

@Component({
  selector: 'app-content-list',
  templateUrl: './content-list.component.html',
  styleUrls: ['./content-list.component.css']
})
export class ContentListComponent implements OnInit {
  contents: Content[];

  constructor(
    private contentService: ContentService
  ) { }

  ngOnInit() {
    this.contentService.getAll().subscribe((res) => {
      this.contents = res.json() as Content[];
    });
  }

}
