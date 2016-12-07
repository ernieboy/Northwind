import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { PaginationComponent } from '../shared/pagination.component';

@NgModule({
    imports: [CommonModule],
    exports: [
        CommonModule,
        FormsModule,
        PaginationComponent
    ],
    declarations: [PaginationComponent]
})
export class SharedModule { }