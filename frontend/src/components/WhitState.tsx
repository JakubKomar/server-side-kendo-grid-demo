import React from 'react';
import { toDataSourceRequestString, translateDataSourceResultGroups } from '@progress/kendo-data-query';
import { Grid, GridColumn, GridProps } from '@progress/kendo-react-grid';

interface DataState {
    skip: number;
    take: number;
    filter?: any;
    sort?: any;
    group?: any[];
}

interface StatefullGridProps extends GridProps {
    data?: any[];
    total?: number;
}

interface StatefullGridState {
    dataState: DataState;
    data?: any[];
    total?: number;
}

export function withState(WrappedGrid: React.ComponentType<any>) {
    return class StatefullGrid extends React.Component<StatefullGridProps, StatefullGridState> {
        constructor(props: StatefullGridProps) {
            super(props);
            this.state = {
                dataState: { skip: 0, take: 20 },
                data: [],
                total: 0,
            };
        }

        componentDidMount() {
            this.fetchData(this.state.dataState);
        }

        handleDataStateChange = (event: any) => {
            const dataState = event.data;
            this.setState({ dataState });
            this.fetchData(dataState);
        };

        fetchData(dataState: DataState) {
            const queryStr = toDataSourceRequestString(dataState);
            const hasGroups = dataState.group && dataState.group.length;

            const base_url = 'api/Products';
            const init: RequestInit = { method: 'GET', headers: { 'Accept': 'application/json' } };

            fetch(`${base_url}?${queryStr}`, init)
                .then((response) => response.json())
                .then(({ data, total }) => {
                    this.setState({
                        data: hasGroups ? translateDataSourceResultGroups(data) : data,
                        total,
                    });
                });
        }

        render() {
            return (
                <WrappedGrid
                    filterable={true}
                    sortable={true}
                    pageable={{ pageSizes: true }}
                    {...this.props}
                    total={this.state.total}
                    data={this.state.data}
                    skip={this.state.dataState.skip}
                    pageSize={this.state.dataState.take}
                    filter={this.state.dataState.filter}
                    sort={this.state.dataState.sort}
                    onDataStateChange={this.handleDataStateChange}
                >
                    <GridColumn field="productId" title="Product Id" filter="numeric" />
                    <GridColumn field="productName" title="Product Name" />
                    <GridColumn field="unitsInStock" title="Units In Stock" filter="numeric" />
                </WrappedGrid>
            );
        }
    };
}
