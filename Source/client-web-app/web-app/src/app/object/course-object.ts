import { BaseObject } from './base-object';

export class CourseObject extends BaseObject {

    CourseId: number;
    CourseName: string;
    DateStart: Date;
    DateEnd: Date;
    Tutition: number;
    public constructor() {
        super();
    }
}
