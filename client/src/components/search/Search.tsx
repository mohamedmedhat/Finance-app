import React, { SyntheticEvent, useState } from "react";

interface Props {}

const Search: React.FC<Props> = (props: Props): JSX.Element => {
  const [search, setSearch] = useState<string>("");

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value);
    console.log(e);
  };

  const searchClick = (e: SyntheticEvent) => {
    console.log(e);
  };

  return (
    <div>
      <input value={search} onChange={(e) => handleChange(e)} className="bg-slate-100 rounded-sm p-2 text-red-600" />
      <button onClick={(e) => searchClick(e)} className="p-2 bg-blue-600 rounded-md">search</button>
    </div>
  );
};

export default Search;
