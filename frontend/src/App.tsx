import React, { useState } from "react";
import { Grid, GridColumn, GridDataStateChangeEvent } from "@progress/kendo-react-grid";
import { DataResult, State } from "@progress/kendo-data-query";
import axios from "axios";
import "@progress/kendo-theme-default/dist/all.css"


const KendoGrid: React.FC = () => {
  const [data, setData] = useState<DataResult>({ data: [], total: 0 });
  const [dataState, setDataState] = useState<State>({
    skip: 0,
    take: 5,
    sort: [{ field: "name", dir: "asc" }],
    filter: {
      logic: "and",
      filters: [],
    },
  });

  const fetchData = async (state: State) => {
    try {
      const page = Math.floor((state.skip || 0) / (state.take || 1)) + 1;
      const pageSize = state.take;

      const requestPayload = {
        page,
        pageSize,
        sort: state.sort,
        filter: state.filter,
      };
      console.log("Reguest:", requestPayload);
      const response = await axios.post("/api/TestGrid", requestPayload);
      console.log("Data:", response.data);

      // Format the response data to match the expected DataResult structure
      const formattedData: DataResult = {
        data: response.data,
        total: response.data.length, // Update this if your API returns the total count separately
      };

      setData(formattedData);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  };

  const handleDataStateChange = (event: GridDataStateChangeEvent) => {
    const newState = event.dataState;
    setDataState(newState);
    fetchData(newState);
  };

  return (
    <Grid
      data={data.data}
      defaultSkip={0}
      defaultTake={5}
      pageable={{
        buttonCount: 4,
        pageSizes: [5, 10, 15]
      }}
      sortable
      filterable
      {...dataState}
      onDataStateChange={handleDataStateChange}
      total={data.total}
    >
      <GridColumn field="id" title="ID" width="100px" />
      <GridColumn field="name" title="Name" />
      <GridColumn field="brand" title="brand" />
      <GridColumn field="price" title="price" filter="numeric" />
      <GridColumn field="addeddate" title="addedDate" />

    </Grid>
  );
};

export default KendoGrid;
