import { Button, ButtonGroup, Table, TableBody, TableCell, TableHead, TableRow } from '@mui/material';
import React, { useEffect } from 'react'

export type TableComponentProps = {

    columns: string[];
    data: any[];
    OnEdit: (id: number) => void;
    OnDelete: (id: number) => void;
    OnClickHeader: (name: string) => void;
}
export default function TableComponent(props: TableComponentProps) {

    useEffect(() => {

    }, [props.data])

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
                        props.data !== undefined ?? 
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
                                <TableCell align="center">
                                    <ButtonGroup aria-label="buttons" style={{ color: "#fb8500" }}>
                                        <Button onClick={() => { props.OnEdit(item.id) }} style={{ color: "#fb8500" }}>
                                            Edit
                                        </Button>
                                        <Button onClick={() => { props.OnDelete(item.id) }} style={{ color: "#fb8500" }}>
                                            Delete
                                        </Button>
                                    </ButtonGroup>
                                </TableCell>
                            </TableRow>
                        ))
                    }
                </TableBody>
            </Table>
        </>
    )
}