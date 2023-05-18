import { Button, ButtonGroup, Table, TableBody, TableCell, TableHead, TableRow } from '@mui/material';
import React, { useEffect } from 'react'

export type TableComponentProps = {
    columns: string[];
    data: any[];
    leftButton : string;
    rightButton: string;
    showButtons: boolean;
    OnClickLeft: (id: number) => void;
    OnClickRight: (id: number) => void;
    OnClickHeader: (name: string) => void;
}
export default function TableComponent(props: TableComponentProps) {

    return (
        <>
            <Table aria-label="Books List">
                <TableHead>
                    <TableRow>
                        {props.columns.map((column, index) => {
                            return (
                                <TableCell key={index} align="right" aria-label={column} onClick={(e) => { props.OnClickHeader(e.currentTarget.ariaLabel!.valueOf()) }} style={{ cursor: 'pointer' }}>
                                    {column}
                                </TableCell>
                            )

                        })}
                    </TableRow>
                </TableHead>
                <TableBody>
                    {
                        props.data.map((item) => (
                            <TableRow key={item[0]}>
                                {
                                    props.columns.map((colum, index) => {
                                        return (
                                            <TableCell align="right">
                                                {item[colum]}
                                            </TableCell>
                                        );

                                    })
                                }
                                {props.showButtons === true ?
                                
                                <TableCell align="center">
                                    <ButtonGroup aria-label="buttons" style={{ color: "#1b84b1" }}>
                                        <Button onClick={() => { props.OnClickLeft(item.id) }} style={{ color: "#1b84b1" }}>
                                            {props.leftButton}
                                        </Button>
                                        <Button onClick={() => { props.OnClickRight(item.id) }} style={{ color: "#1b84b1" }}>
                                            {props.rightButton}
                                        </Button>
                                    </ButtonGroup>
                                </TableCell>
                            
                                : ""}
                                
                            </TableRow>
                        ))
                    }
                </TableBody>
            </Table>
        </>
    )
}