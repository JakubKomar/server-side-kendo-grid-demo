import React from 'react';
import { Grid, GridColumn } from '@progress/kendo-react-grid';
import { withState } from './WhitState';

const StatefullGrid = withState(Grid);

const GridExample: React.FC = () => {
    return (
        <div>
            <StatefullGrid>
                <GridColumn field="productId" title="Product Id" filter="numeric" />
                <GridColumn field="productName" title="Product Name" />
                <GridColumn field="unitsInStock" title="Units In Stock" filter="numeric" />
            </StatefullGrid>
        </div>
    );
};

export default GridExample;
