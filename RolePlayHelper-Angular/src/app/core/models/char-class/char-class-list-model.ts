export interface CharClassListModel {
  id: number;
  name: string;
  description: string;
  parentClassId: number | null;
  parentClass: string | null;
  subClassNames: string[];
}
