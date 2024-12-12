﻿using AdventLibrary;

namespace Day_12___Garden_Groups
{
    internal class Input
    {
        public static Matrix<char> GetData()
        {
            return MatrixParser.Parse("SSFFFFFFFFFFFFFFFFEEEZZZZRZZZZZZZZZZZKKKKKKKKKKKKKKKSSSSSSSSSSSSSKKKKKKKKKQDDDDDTTTTTTTTTTTTTTMMMMMMMMMWWWWWWWWWWYYWKKKKKKKKKKKKKKKKKKKKKKKK\r\nFFFFFFFFFFFFFFFFFFFEEEZZZZZZZZZZZZZZZZKKKKKKKKKKKKKKSSSSSSSSSSSSSKKKKKXXXXXXXXXDDDTTTTTTTTTTMMMMMMMMMMMMWWWWWWWWWWWWKKKKKKKKKKKKKKKKSKKKKKKK\r\nFFFFFFFFFFFFFFFFFFFFEEZZZZZZZZZZZZZZZKKKKKKKKKKKKKKKSSSSSSSSSSSSSKKKKKXXXXXXXXXDDQQTTTTTCTTTTMMMMMMMMMMKMWWWWWWWWWWWKKKKKKKKQKKKSSSSSSKKKKKK\r\nFFFFFFFFFFFFFFFFFIIIIEEZZZZZZZZZZZZZZKKKKKKKKKKKKKSSSSSSSSSSSSSKKKKKKKXXXXXXXXXDDQQQTTTTCTTTTMMMMMMMMMMMMWWWWWWWWWWWKKKKKKKKQQQQSSSSSSSSKKKK\r\nVVVFFFFFFFFFFFIIIIIIIEEZZZZZZZZZZZZZZKKKKKKKKKKKKKSSSSSHHHSHHSSKKKKKKDXXXXXXXXXDQQQQQTTTCCTTTMMMMMMMMMMMMMMWWWWWWWWWKKKKKMMKKQQQSSSSSSSSKSSK\r\nVVVFFFFFFFFFFFFIIIIIIEZZZZZZZZZZZZZZZKKKKKKKKKKKKKKSSSSHHHHHSSSSKKKKKIXXXXXXXXXDQQQQTTTTCCTTMMMMMMMMMMMMMMMMWWWWWWKKKKMMMMMMQQQQSSSSSSSSKSSK\r\nVVVVFAFFFFFFFFFIIIIIIIIZZZZZZZZZZZZZZKKKKKKKKKKKKKKKSSSSHHHSSSSSKKKKKIXXXXXXXXXDQQQQQTTTCTTMMMMMMMMMMMMMMMMWWWWWWWWWKWWMMMMQQQQQSSSSSSSSSSSK\r\nVVVVFFFFFFFFFFFIIIIIIIIIIZZZZZZZZZZZKKKKKKKKKKKKKSKSSSSVSHHSSSSSSSSSKDXXXXXXXXXXXQQQQQQTCTTMMMMMMMMMMMMMMMMWWWWWWWWWWWWQQMQQQQQQQSSSSSSXSASK\r\nVVVVVFFFFFFFFFFLLIIIQQIPPPPZZZZZZZZZKKKKKKKKKKKKKSSSVVVVSSSSSSPSSSSHDDXXXXXXXXXXXQQQVVTTTTTMMMMMMMMMMMXXXXXWWWWWWWWWWWWWQQQQQQQQQSSSSSXXSSKK\r\nVVVVVFVFFFFFFAAIIIQQQPPPPPPZZZZZZZZZKKAKKKKKKKKKMUUSSWVVVVSSSSPSSSSHDDXXXXXXXXXXXSVQVVTTTTTMMMMMMMMMMMXXXXOWWWWWWWCWWIWQQQQQQQQQQQSSSSXXXSKK\r\nVVVVVVVFFFFFFAKCIQQQPPPPPPEEZIZZZZZKKAAAKKKKKKKXUUSSUWVVVVSSPPPPESHHHDXXXXXXXXXXSSVVVVTTTTTTTMEMMMMXXXXXXOOZWWWWWWWIIIWWQQQQQQGGQQQXXXXXXXXX\r\nVVVVVVVVFFFFAAKKKKQQQPPPPPPEEEEAAZZZZZAAAAKAAKJXUUSSUUVVVPPPPPPPESSHHDFXXXXXXXXXSSSVVVTTTTTATEEMMMMMMXXXXOOOOOOIWIIIIIIWWQQQQQYGXXXXXXXXXXXZ\r\nVVVVVVVVVVFFAKKKKKPPPPPPPEEEEEEAAAZZAAAAAARRRRRRUUUUUUUVVVPPPPPMPPPHHHDDDDDDDDSSSSSSSSTTTTTTTEEEMEMMMMXXOOOOOOOIIIIIIIIWIIQQQGGGGGXXXXXXXZZZ\r\nVVVVVVVVFFFAAKKKKKRRRPPEEEEEEEEEAAAAAAAAAARRRRRRJUUUUUUVVIPPPPPPPPPHHHHHDDDDDDSSSSSSSEEEEETEEEEEEEJJJJOOOOOOOOOIIIIIIIIWILQQEGGGGGXXXXXXXXZZ\r\nVVVVVVVVJJJVAAAAAKRRRRREREEEEEEEEEEAAAAAARRRRRRRRRRUUUUIIPPPPPPPPPHHHHHHDDDDSSSSSSSESEEEEEEEEEEEEEJJJJOOOOOOOOOIIIIIIIIIIGGGGJGGGGGGXXXXXXZZ\r\nVVVVVVVVVVVVXXXXAKRRRRRRREEEEEEEEEEAAARRRRRRRRRRRRRUUUUUIPPPPPPPQPPPHHHHDDDDSSSSSSSEEEEEEEEEEEPEPPPOJJOOOOOOOIIIIIIIIIIIIGGGGGGGGGGXXXXXXXZZ\r\nAVVVVAVVVVVXXXXXXRRRRRRREEEEEEEEEAAAAAARRRRRRRRRRRRJJUUUPPPPPPQQQPPHHHHHHSSDDSSSSSEEUEEEEUUEEPPQQQQQQQOOOOOOOOIIIIIIIIIIIGGGGGGGGGGGGXXXHXZZ\r\nAVVAAAAVVVVXXXRRRRRRRRRREEEEEEEEEAAAAAARRRRRRRRRRRRJJJJUPPPPPPQQQHHHHHHSSSSSSSSSSSEEUUUUUUUEPPPQQQQQQQOOOOOOIIIIIIIIIIIIIGGGGGGGGGGGGGXXXXXZ\r\nAAVAAAAAVVVVXXXRRRRRRRREEEEEEEEEEAAAAARRRRRRRRRRRRRJJPJJJPPPPPQHQHHHHHHSSSSSSSSSSEEUUUUUUUUUUPPQQQQQQQOOOOOOOIIIIIIIIIIIIIGGGGGGGGGGGGXXXXZZ\r\nAAAAAAXXXVVVXXXXXRRRRRRREEEEEEEEEAAARRRRRRRRRRRRRRRPPPJJJPPPPPHHHHHHHHSSSSSSSSSSSEEUUUUUUUUUUUPQQQQQQQOOOOOOOOIIIIIIIIIIGGGGGGGGGGGGGGGGGZZZ\r\nAAAAAAAAXXXXXXXXXXRRRNNNNNEEEEEEEXXARRRRRRRRRRRRRRRPPPPJJHHIIIHHHHHHHHSSCSSSSSSSSSEUUUUUUUUUUUPQQQQQQQOOOOOOOOOOIIIIIIIIGGGGGGGGGGGGGGGGGZZZ\r\nAAAAAAAXXXXXXXXXXRRRRNNNNNNEEEEEXXXARRRRRRRRRRRRRRRPPPPHHHIIIIIIHHHHHHHHSSSSSSSSSXUUUUUUUUUUUPPQQQQQQQQQQQQQQQOIILLIIIIIGRRGGGGGGGGGGGGGGZZZ\r\nAAAAAAAAXXXXXXXXXXNNNNNNNNNEHHXXXXXXRRRRRRRRRRRRRRRPQPPHHHIIIIIHHHHHHHOGGSSSSSSSSXUUUUUUUUUEPPPQQQQQQQQQQQQQQQQQQQLLIIIIRRGGGGGGGGGGGZGZZZZZ\r\nAAAAAAAAXXXXXXXPXXXNNNNNNNNHHHHXXXXXRRRRRRRRRRRRPJPPPPPPHIIIIIIUHHHHHHOGGGOXXXXXXXXXDDDUUUVPPPPQQQQQQQQQQQQQQQQQQQLLLLRRRLEEGZGGGGGGGZZZZZZZ\r\nAAAAAAAAXXXXXXXXAANNNNNNNNNNNNNNXXXAAJQQQQRRRRRRPPPPPPPPPPDIIUIUOXHHWOOGOGOXXXXXXXXXDDDDUUVVPPPQQQQQQQQQQQQQQQQQQQLLLLLLLLLGGZGZZGGTTZZZZZZZ\r\nAAAAAAAAAXXXXXXXAAANNNNNNNNNNNAXXXXAAAQQQQRRRRRRPPPPPPPPPPDIIUUUOOGHHEOOOOOXXXXXXXXXXXXDVVXPPPQQQQQQQQQQQQQQQQQQQQLLLLLLLLLLLZZZZGGZZZZZZZZZ\r\nAAAAAAAAAAAAXOXWNNNNNNNNNNNNNAAXXXAAQQQQQQRRRRRRPPPPZPPPPPPZOOUUOOOOEEOOOOOXXXOXOOXXXXXDVXXPPPQQQQQQQQQQQQQQQQQQQQLLLLLLLLLLLZZZZGZZZZZZZZZZ\r\nAAAAAAAAAAAAAWWWWNNNNNNNNNNNNNAAXXXAAQQQDDRRRRRRPPPZZZZZZZZZOOUOOOOOOOOOOOOOOOOOOXXXXXXXXXXZPPQQQQQQQQQQCCCYCCCCHLLLLLLLLLLLLZZZZZZZZZZZZZZZ\r\nAAAAAAAAAAAWWWWWWNNNNNNNNNNNNAAAAAAAHDDQQZRRRZPMPPPZZZZZZZOOOOOOOOOJJOOOOOOOOOOOOXXXXXXXXXZZZZQQQQQQQQQQCGCCCCCCCCCLLLLLLLLLLLZZZZZZZZZZZZZZ\r\nAAAAAAAAAAAWWWWWNNNNNNNNNNNNAAVAAAAAHDDDDZRRRZZZPPPZZZZZZZFFFFFFOOJJJJOOOOOOOOOOOXXXXXXXXXZZZZPPPRRRPOOFFCCCCCCCCLLLLLLLLLLLLLZZZZZZZZZZZZZZ\r\nAAAAAAAAWAWWWWWWNNNNNNNNNNNNANVVVVHHHDDZZZRRRZZZPPZZUUZZZFFFFFFJJJJJJJJOOOOOOOOOOXXXXXXXXZZZPPPPRRRRRLOLLCCCCCCCCCCLLLLLLLLLZZZZZZZZZZZZZZBB\r\nAAAAAAAAWWWWWWWWWNDDNNNNNNNNNNVVVHHHHHHXXXZZZZZZZPZZZUZZZFFFFFFJJJJJJJJOOOOOOOOOXXXXZXZZZZZZZPPZRRRRRLOLCCCCCCCCCCCLLLLLLLLLZZZZZZZZZZZZZBBE\r\nAAAAVAAAWWWWWWWWWNDDNWNNNNNVVVVVKKKHHHXXXXZZZZZTZZZUUUUUUFFFFFFJFJJJJJJOOOOOOOOXXXPXZZZZZZZZZZZZRRRRRLLLLCCCCCCCCCLLLLLLLELLZZZZZZZZZZZZBBBB\r\nAAAVVVAAAWWWWWWWWNDDNLNNNNLVVVVVKKKHXXXXXTTTTTTTTUUPUUUUUUFFFFFFFFJJJJJJJMSOOZXXXXXZZZZZZZZZZZZRRRRRRRLLLCFCCCCCCCCCLLLLLEEZZZZZZZZZZZZZZBBB\r\nAAVVVAAWWWWWWWWWWWLLLLINLLLVVVVVKVVXXXTTTTTTTTTTUUUUUUUUUVVVFFFJFFJJJJJJMMMMOZZXXXZZZZZZZZZZZUZRRRRRLLLLLCCCCCCCCCCLLLLLLEEEZZZZZZZZZZZBBBBB\r\nAAAVVVVVVWWVVWWWWWLLLLLLLLLVVVVVVVXXXXTTTTTTTTTUUUUUUUUUVVVVJFJJJJJJJJJMMMMMMZZZZZZZZZZZZZZZZUZZZRRLLLLLLLLLCCCCCCCCCLLLLLLEZZZZZZZZZZBBBBBB\r\nFFVVVVVVVVWVWWWWWLLLLLLLLLLVVVVVVVVXXTTTFTTTTTTUUUUUUUUVVVJJJJJJJJJJJAMMMMMMMMMZZZZZZZZZZZZUUUUZZZRRLLLLLLLLLLCCCCCFCLLLLLLEEEEGGGZZZZBBBBBB\r\nFFFFFVVVVVVVVWWWWLLLLLLLLLLLVVVVVVVTTKTTTTTTTTTUUUUUUUUUVVJJJJJJJJJJJAMMMMMMMMZZZZZZZZZZZZUUUUUZZZRLLLLLLLLLLLLCCLLLLLLLLLLEGEGRRGGZBBBBBBBB\r\nVVFFVVVVVVVVVWWJLLLLLLLLLLLLVVVVVVVVTTTTTTTTTTTTNUUUUUUUVVJJJJJJJJAAAAAAMMMMMMMZZZZZZZZZZUUUUUUULLLLLLLLLLLLLLLLLLLLLLLLLIIGGGGRRGGGBBBBBBBB\r\nVVFFFVVVVJJJJWJJLLLLLLLLLLLLVPPVVYYYTTTTTTTTTTTTNUUUUUUUVVJJJJBIBBAAAAAMMMMMMMPZZZZZZZZZZZZUUUUMLLLLLLLLLLLLLLLLTLLLLNNNNIIGGGGGGGGGBBGBBBBB\r\nVFFVVVVVJJJJJJJJJMLLLLLLLLPPPPPPPYYTTTTTTTTTTTTTTOUUUUUUVVVBJJBBBBMAAAAMMMMMMMMZZZZZZZZZZZZUUUUMMLLLLLLLLLTLLLTTTLLLLNNNANGGGGGGGGGGGGGBBBBB\r\nVVVVVVVVVJJJJJJJJJUULLLLLLPPPPPPPYYYTTTTTTTTTETTOOOOOUVUVVVBBBBBBMMMMMMMMMMMMMMZZZZZZZZZZZZRZZMMMMMLLLLLLLTTTTTTTLLLTNNNNNNGGGGGGGGGGHGBBBBB\r\nVVVVVVVVJJJJJJJJJJUUZLLZZLPPPPPDPPZATTTTTTTTTTTTTOOOOVVVVVVBBBBBBBMMMMMMMMMMQQQQZZZZZZZZZZZZZZZMMMMMLLLTTTTTTTTTLLNLNNNNNNGGGGGGGGGGGGGGBBBB\r\nVVVVVVVVVPJJJJUGZZZZZZZZZZPPPPPPPPPAAAATTTTTTTYYYOOOOVVVVVVBBBBBBBMMMMMMMMMMQQQQZZZZZZZZZZZZZZZMMMMMMMMMMTTTTTTTLNNNNNNNNNNNGGGGGGGGGGGGBBBB\r\nVPPPPPPPVPKKKGGGGZZZZZZZZZZPPPPPPPPAAAAAAATTTTYOOOOOVVBVVVVBBBBBBBBBBBMMMMMMQQQQZZZZZZZZZZZZZZZZMMMMMMMMMTTTTTTTTLLNNNNNNNNNGGGGGGGGGGGGBBBB\r\nVPPPPPPPPPKGKGGGGZZZZZZZZZZPPPPPPPPPPPPAAATTTTTTJOOOVBBBVVBBBBBBBBJBBBMMMMMMQQQQZZZZZZZZZZZZZZZZZMMMMMJMMTTTTTTPNLNNNNNNNNGGGGGGGGGGGGGGGGBB\r\nVPPPPPPPPKKGGGGGGZZZZZZZZZZPPPPPPPPPPPPAAAAAAATHHOOVVBBBBBBBBBBBBBBBBMMMMMMMQQQQQZZQQQQQQZZZZZZZZMJJJJJMMMMMTYTPNNNNNNNNNNNGGGGGGGGGAGGGGBBB\r\nVPPPPPPPPPPGGGGGGGZZZZZZZZZZZPPPPPPPPPAAAAAAHHHHHOOBBBBBBBBBBBBBBBHHHMMMMMMSQQQQQZZQQQQQQZZZZZZZZZZZMJJJMMTTTYYNNNNNNNNNJJNUGGGGGGGAAAGGGBBB\r\nQWWPPPPPPPPGGGGGGGZZZZZZZPPPPPPPPPPPPPPPAAAAHHHHHBBBBBBBBBBBBBBBBBHHHMHMMMMMQQQQQZZQQQQQQZZZZZZZZZZZZJJJMJYYYYYYYNNNNNNKKKUUGGGGKGAAAAGGOBBB\r\nQPPPPPPPPPPGGGGGGGGZZZZZPPPPPPPPPPPHPHHHHAAAAHHHHHBRRRBBBBBBBBBHHBHHHHHHMSSSQQQQQBZQQQQQQZZZZZZZZZZJJJJJJJYYYYYYYFFNNNNKKKUUGGGOKGGOAAAOOOBB\r\nQPPPPPPPPPPPBAAAGGGZPOZPPPPPPPPPPPHHHHHHHAAAAHHHHHHRRRRRBBBBBBBBHHHHHHMMMSSQQQQQQQQQQQQQQQZZZZZZZZJJJJJJJJYYYYYFFFFNFFIKKKKKKZGOKKOOAAAAOOOO\r\nQQPPPPPPPPPAAAAAAAGZPPPPPPCPPPPPPPPPHHHHHHHHHHMHHHRRRRRWRBBBBBBBHHHHHHIIMMMQQQQQQQQQQQQQQQZZZZZZJJJJJJJJJJJYZZZFFFFFFFKKKKKKKZKKKOOOAAAAOOOO\r\nQQPXPPPPPPPAAAAAAGGGPPPPCCCPPPPPPPPPPPPHHHHHMMMMMRRRRRRWRDDDDDDHHHHHHIIIIMMQQQQQQQQQQQQQQQQQQQZZJJJJJJJTJJZYZZZZZFFFFZZKKKKKKKKKKKOAAAAOOOOO\r\nQQPPPPPPAAAAAAAAAAGGPOOPCCCPPPPPPPPPPPPPPHHHMMMMMMRRRRQQQDDDDDDHHHHHHIIIMMMQQQQQQQQQQQQQQQQQQQZZJJJJJJJJYYZZZZZZZFFFFZZKKKKKKKKKKKKKKKOOOOOO\r\nQQPQPPPBAAAAAAAAADAOOOOCCCEPPPPPPPPPPPPPHHHMMMMMRRRRRRQQQDDDDDHHHHDGHIMMMMMMMXXXSSQQQQQQQQQQQQJJJJJJJJJJYZZZZZZZZZZZFZZKKKKKKKKKKKKKKEEOOOOO\r\nQQQQPPPPAAAAAAAAAAAOOOCCCCECCPAPAPPPPPPPHHMMMMMMMMRRDDQQQDDDDDHDDDDDIIIIMMMMMIXXSSQQQQQQQQQQQQJJJJJJJJYYYYZZZZZZZZZZZZZKKKKKKKKKKKKKREEEOOOO\r\nQQQQQPPPAAAAAAAAAACCCOCCCCCCPPAAAPAPPPPFFMMMMMMMMMMDDDQQQDDDDDDDDDDIIDIIMIMMMIXXXXSSZZZQQQQQQQJJJJJJJJYYYYZZZZZZZZZZZZZZZKKKKKKKKKKKEEEEEOOO\r\nQQQQQGPPPAAAAAAAAAACCCCCCCCCCBPPPPFFFFFFMMMMMMMMMMMMDDQQQDDDDDDDDDDDDDDIIIIIIIXXXXUSZZZQQQQQQQJJJJJJJJJJJYZZZZZZZZZZZZZZZKKKKKKKKKKKEEEEEOOO\r\nQGGGGGPAAAAAAAAACCCCCCCCCCCCCCIIPPPFFFFFFFMMMMMMMMMMDQQQQLLLDDDDDDDDDDDDIIIIIXXXXXXZZZZZZZZZJJJJJJJJJJJJYYYZZZZZZZZZZZZZKKKKKKKKKKKKKEEEOOOO\r\nQQQGGGPAAAAAAACCCCCCCCCCCCCCCCCIIFFFFFFFMMMMMMMMMMMMMQQQQLLDDDDDDDGDDSOOOIIIXXXXXXXXXXXZZZJJJJJJJJJJJJFFWWYZZZZZZZZZZEEEKKKKKKKKKKKKKEEEOOOO\r\nQQGGGGGGGAAAAACCCCCCCCCCCCCCCCIIIFFFFFFFFMMRRMMQQQQQQQQQQLLLDDLLDGGGDSOOOOXIXXXXXXXXXXXXKKJJJJJJJWNWWWWWWYAAAAZZZZZEEEEEEEKAKKKKKKOKEEEEEEOO\r\nQQGGGGGGAAAAAAAACCCCCCCCCCCCCCIIIFFFFFFFFMMAAJJQQQQQQQQQQLLLDDLDDGGYOOOOFXXXXXXXXXXXXXXZKJJJJBJTJWWWWWWWWYAAAAZZZZZZEEEEEEKEEOOOOKOKEOEEOOOO\r\nQQGGGGGGGGGGAAAACCCCCCCCCCCIIIIIIIFFFFFFMMMAAAAQQQQQQQQQLLLLDDLLGGGGGOOOOXXXXXXXXXXXXXXZKJJJJBWWWWWWWWWWWWAAAAVVVZEEEEEEEEEEEOOOOOOOOOOOOOOO\r\nQQQGGGGGGGAAAAACCOCCCOOOOOCCIIIIIFFFFFFFFFFAAAAQQQQQQQQQLLLLLLLGGGGGGOOOOOXXXXXXXXXXXXXKKKKKJBWWWWWWWWWWWWAAAAVVVEEEEEEEEEEEOOOOOOOOOOOOOOOO\r\nQQQQGAGGXGAAAAAOOOOOCOOOOOCIIIIIIIFFFFFFFFFAAAAQQQQQQQQQLLLLLNNGGGGGOOOOOOXXXXXXXXXXXXXEKKKKKKKWWWWWWWWWAAAAAAVVVEEEEEEEEEEEOOOOOOOOOOOOOOOJ\r\nQQQQQGGGAAAAAAAOOOOOOOOOORCIIIIIIIIIFFFFFFHHAAAQQQQQQQQQQLLLLNGGGGGOOOOOOOXFXXXXXXXXKKKKKKKKKKKKWWWWWWWWAAAAAAVAVEEEEEEEEEEOOOOOOOOOOOOOOJJJ\r\nQQQQUUUUUUAAAAOOOOOOOOOOOOCIIIVVIIIIFFFFFFFHASAQQQQQQQQQQLLLLNGGGGGGOOOOOOXXXXXXXXXXXKKKKKKKKKKKWWWWWWWWAAAAAAVVVEEEEEEEEEEOOOOOOOOOOOOOJJJJ\r\nQQQQQUEUUUAAAOOOOOOOOOOOOOOIIVVIIIIIFVFYFFSSSSSQQQQQQQQQQLLLLGGGGGGGGOOOOOOXXXNXNXXXXKKKKKKKKKKWKWWWWWWWAAAAAAVVVVEEEEEEEEEEOOOOOOOOOOOJJJJJ\r\nQQQQQEEEEUUAAOOOOOOOOOOOOOOIIVVVIIIIIOOOSSSSSSIQQQQQQQQQQLLLLGGGGGGGGOOOOOOOXXNNNXXXXKKKKKKKKKKKKKWWWWWWAAAAAAWKKVKKEEEEEEEEOOOOOOOOOOOJJJJJ\r\nQQQQQEEEEUUEEOOOOOOOOWZZOOOVVVVVVVVIIOOOOSSSSSSQQQQQQQQQRRLLLLUGGGGGGOOOOOOONNNNNXXONNKKKKKKKKKKKKKWWWWWAAAAAAKKKVKKEEEEEEEEOOOOOOOOOOJJJJJJ\r\nQQQQQEEEEEEEEOOOOOOOSWZWWWVVVVVVVVYIOOOOSSSSSSSQQQQQQQQQLLLLLLLLLGGGGOOOOOOOANNNNNNNNNKKKKKKKKKKKKWWWWWWAAAAKWKKKKKEEEEEEEEEOOOOOOOOOOOJJJJJ\r\nQQQQEEEEEEEEEBOOOOOOOWWWWWVVVVVVVVYYYVOOOOSSSSSQQQQQQQQQLLLLLLLLLAAGHOOONNNNNNNNNNNNNUKKKKKKKKKKKZWZWZZWAAAAKKKKKFKKEEEEEEEIOOOOOOOOOOOJJJJJ\r\nQQQQQEEEEEEEEWWWWOOOWWWWWWVVVVVVVVYYYYOOYOOOOSTQQQQQQLLLLLLLLLLLLAGGHHHONNNNNNNNNNNNNUUKKKKKKKKKZZZZZZZZAAAAKKKKKFEEEEEEEEEEOOOOOOOOOOOOJJJJ\r\nQQQQEEEEEEEEEWWWWWWWWWWWWWVVVVVVVVYYYOOJYOOOOSSTTTTTLLLLLLLLLLLLLLLLHHHOHHHNNNNNNNNNNUUKKKKKKKKYYYYYZZZZAAAAKFFKKFFFEEEEEEEBBOOOOOOOOOOJJJJJ\r\nQQEEEEEEEEEEWWWWWWWWWWWWWWVVVVVVVYYYYOYYYYYOOOOOOOTTTLLLLLLLLLLLLLLLHHHHHHNNNNNNNNNNNNKKKKKKKKKYYYYYZZZZZZKKKFFFFFFFFEDDDDDOOKOOOTOOOKJJJJJJ\r\nQQQEEOEEEEEEWWWWWWWWWWWWWWWVVVVVYOYYYYYYYYYYOOJOOOOTTLLLLLLLLLLLLLLLHHHHHHHNNNNNNNNNNNNKKKKKEKZYYYYYZZZZZHKKKFFNFFFFFODDDDOOOOOOOTOOKKJJJJJJ\r\nQQQQQEEEEEEWWWWWWWWWWWWWWWPPPVPVYYYYYYYYYYYJJOJJOOOTTTTLLLLLLHHLLLHHHHHHHHJNNNNNNNNNNNKKKKKKZZZYYYYYZZHHHHHKKKFFFFFFFDDDDDDOOOOOOTTJJKJJJJJJ\r\nQQQOQQEEEEWWWWWWWWWWWWWWWWWWPPPPPYYYYYYYYYJJJJJTTTTTTTTWWWHHHHHHLHHHHHIIIHJBJGNNNNNNNSKKKKKKZZZYYYYYZZZZHHHHHFFFFFFFFDDDDDDUOOOOOOTJJJJJJJJJ\r\nQOOOOOOEEEWWWWWWWWWWWWWWWWWPPPPPPYYYYYYYYYYYYJJJJTTTTTTWWOHHHHHHHHHHJJIIIJJJJNNNNNNNNJJJCCKKZZZZZZZZKZHHHHHFFFFFFFFFFDDDDLLLLOOOOOJJJJJJJJJJ\r\nQOPOOOOOWWWWWWWWWWWWWWWWWWPPPPPPPPYYYYYYYYYYNNNJTTTTTTTWWHHHHHHHHHHHJJIIIJJJJJNNNNNNNJJJJJJWZZZZZZZZZZZHHHHHHFFFFFFFFDLLLLLLLLOOOOOJJJJJJJJJ\r\nQOOOOOOEEEEEWWVWBBWWWWWWWPPPPPPPPPPYYYYYYYYYYNNTTTHHHTTWWHHHHHHHHHHHJJIIIJJJJJWNNNNNNJJJJJJZZZZZZZZZZZZHHHHHFFFFFFFFFFLLLLLLLLOOOOJJJJJJJJVV\r\nOOOOOOOOEEEWWWVWBBBWWPPPPPPPPPPPPPPYYYYYYYYYTTTTTTHHHHHWWHHHHHHHTHHHJJIIIJJJJJJNNNNJNJJJJJJJJZZZZZZHZZHHHHHHFFFFFFFFFFLLLLLLLLOOJJJJJJJJJJVV\r\nOOOOOOOOEEEWWWVVVBBBBBPPPPPPPPPPPPPYYYYYYTYTTTTTTTVHHHHHHHHHHHHHHHHJJJIIIJJJJJJIVINJJJJJJJJJBBZZZHHHHHHHHHHHHFFFFFFFFFLLLUUULLOOOJJJJJJJJJVV\r\nSOOOOOOSZZZZVVVBBBBBBBUPPPPPPPPPPPPTTTYYYTYYTTTTTTTGGGGGHHHHHHHHHHSSHHHHHJJGJJJIIIIZJJJJJJJJBBZZHHHHHHHHHHHHHFFFFFFFFFLLLUUULLOOOOJJJJJTTTVV\r\nSSSSSSSSSSSZZZZNBBBBBUUPUPPPPPPPPITTTYYTTTYTTTTTTTTGGGGGGHHHHHHHHHHHHHHVHJEJJJIIIIIZJJJJJJNJJHHHHHHHHHHHHHHHFFFFFFFFFFUUUUUULOOOOOOOOVKVVVVV\r\nSSSSSSSSSSZZZZZZBBBBBBUUUPPPPPPPPITTTTTTTTTTTTTTXXXXXXGGGGGHHHHHHHHHHHHIJJJJIIIIIIIIEEJJJNNNHHHHHHHHHHHHHHHHHFFIIIIIFIUUUUUULOOORROOOVVCVVVV\r\nSSSSSSSZZZZZZZZZZBBBBBUUUUUPUUVVPPPTTTTTTTTTTTTTXXXXXXGGGQGHHHHHHHHHCHHIIJJJIIIIIIIIEEEJNNNNHHHHHHHHHHHHHHHHHFFIIIIIIIUUUUUULORRRRROOVVVVVVV\r\nSSSSSSZZZZZZZZZZZBBBBUUUUUUUUUUVPZVTTTTTTTTTTTTTXXXXXXGGGGGHHHHHHHHHCCIIIJIIIIIIIIIIEJJJJNNNXXXXXHHHHHHXHHHHHHFIIIIIIIUUUUUULCCCCCVVVVVVVVVV\r\nSSSSZZZZZZZZZZZZBBBBBBBUUUUVVVVVPVVVTTTTTTTTTTTTXXXXXXGGGGGHPHHPHCHCCCIIIIIIIIIIIIIIJJJJJNNNXXXDHHHHHHHXHHHHIEEEIIIIIIUUUUUUCCCCCCVVEVVVVVVV\r\nSSSZZZZZZZZZZZZBBBBBBBUUUUUVVVVVVVVVTTTTTTTTTTTTTXXXXGGGGUGUPPPPCCCCCCIIIIIIIIJIJJJJJJJJNNXXXXXXHHHHHHXXXHHXIEIIIIIIIIUUUUUUCCCCCCCCVVVVVVVV\r\nSSSSSZZZZZZZZZYBBBBBBBUUEUEVVVVVVVVVVVOTTTTTTTTTXXXXXXXGGUUUPPPPPPPCCCIIIIIIIIJJJJJJJJJJJNNXXXXHHHHHXXXXXXXXIIIIIIIIIIUUUUUUCCCCCCCCCCCCVVVV\r\nSSSSSSZZZZZZZDYYBBBBBBBEEEEVVVVVVVVVVVVJJTTTTTPPXXXXXXXGUUUUPPPPPPPCCIIIIXXIIIJJJJJJJJJJJJXXXXXXXXXXXPXXXPPXIIIIIIIIIIUUUUUUCCCCCCCCCCCCVVVV\r\nSSSSSSZZZZZZYYYYYBSSBBBBEEEEVVVVVVVVVVVVJJTJJPPPXXXXXXXGUUUPPPPPPPPPPXXIXXXXIIJJJJJJJJJJJJXXXXXXXXXXXPPPPPPXPPPIIIIIIIUUUUUUCCCCCCCCCCCCVVVV\r\nSSSSSSSSZZZZZYYSSSSIBBBBEEEEVVVVVVVVVVVVJJJJJJJPXXXXXXXUUUUUPPPPPPPPPYXXXXXIIIJJJJJJJJJJJJFFXXXXXXXPPPSPPPPPPPPHIIIIIIRRRRCCCCCCCCCCCCCCVVVV\r\nSSSSYYYZZZZYZYYYSSSSSSEEEEEEVVVVVVVVVVVJJJJJJJJJXXXXXXXUUUUUPPPPPPPPPXXXXXXXIIIJIAJJJJJJJJFFXXXXXXXPPPPPPPPPPHHHIIINIIRRPRCCCCCCCCCCCCCCVVVV\r\nSSYSYYYYYYYYYYYYYSNEEEEEEEEEVVVVVVVVHHVJJJJJJJJXXXXXXXXUUUUPPPPPPPPXXXXXXXXIIIIIIJJJJJJJJFFFFXXXXXPPPPPPPPPQPHHHINNNNNRRPPCCCCCCCCCCCCCCVVVV\r\nSSYYYYYYYYYYYYYYYNNEEEESEEEEEVVVVVVHHHHJJJJJXXXXXXXXXXXGUUUUPPPPPPPDDXXXXXIIIIIIIJJJJJJJJFFFFXXCXXXPPPPPPPPPPPPHINNNNNNRPPAAAAAAACCCCCCCVVVD\r\nYYYYYYYYYYYYYYYNNNEEEEEEEEEEEVVVVVVHHHHHJJJJXXXXXXXXXXXGGUUUPPPPPPPDDDXXXXIIIIIIOOJJJOOJOYYYFXYCXXXJPPPPPPPPPPPPPNNNNNNNPPPAAAAAACCCCCCCVVVD\r\nYYYYYYYYYYYYYYYNNENEEEEEEEEEEVVVVVHHHHHHJJJJXXXXXXXXUUUUGUUUUUPPKKKDDDDDXXIIIIIOOOOOOOOOOYYYYYYXXXXXPPPPPPPPPPPPNNNNNNNNNPAAAAAAACCCCCCCNVVD\r\nYWWYYUYYYVYYYYYEEEEEEEEEEJEEVVVVVHHHHHHHJJJJXXXXXXXXGGGGGGGUGUUPPKKKKDDDDIIIIIIOOOOOOOOOOYYYYYYBBBBEEEEEEEEEEPPPNNNNNNNNNNAAAAAAACCCCCCCNNNN\r\nWWWWYVTTVVVVXXEEEEEEEEEEEJJEEVSVVVHHHHHHJJJJXXXXXXXXMGGGGGUUGGGGKKKKWDDDDDDIIIAOOOOOOOOOYYYYYYYBBBBEEEEEEEEEEPPPPNNNNNNNVNAAAAAAAAANNNNNNNNN\r\nWQWWYVTVVVVVEEEEEEEEEEEEEEJJJSSSSVSSSHSSSSJJXXXXXXXXGGGGGGGGGGGGKKKKWWDDDDIIIIIOOOOOOOYYYYYYYYYBBBBEEEEEEEEEEPPNNNNNNNNNNNBANAAAAAANNNNNNNNN\r\nQQWVVVVVVVVVVEEEEEEEEEEEEDSSSSSSSSSSSSSSSSSJXXXXXXXXGGGGGGGGGGNGKWKKWWWDDDDDIIIOOOOOOOOYYYYYYYYBBBBEEEEEEEEEENNNNNNNNNNNNNNANNNNAAAANNNNNNNN\r\nVQQVVVVVVVVVVVEEEEEEEEEEEDSSSSSSSSSSSSSSSSSJXXXXXXXGGGGGGGGGGGGGKWWWWWWWDDDDDIIDOOOOOOOOYYYDYYHBBBBEEEEEEEEEEPNNNNNNNNNNFNNANNNNNNMMNNNNNNNN\r\nVVVVVVVVVVVVVVEEREYEEEEDDDDSSSSSSSSSSSSSSSSSXXXXXXXGGGGGGGGGGGGGGWWWWWWWDDDDDDDDOOOOOOOOJYYHHEEEEEEEEEEEEEEEEPNNNNNNNNNNNZNNNNNNNNNNNKNNNNNN\r\nGVGVVVVVVVVVVVVEYYYYDEDDDDDSSSSSSSSSSSSSSSSYYYGGGGGGGGGGGGGGGGGGGWWWWWWDDDDDDDDDOOOOTOOOOYYHCEEEEEEEEEEEEEEEEPNNNNNNNNNNZZZZNNNNNNNNNKNNNNNK\r\nGGGVVVVVVVVVVVVYYYDDDEDDDDSSSSSSSSSSSSSSSSSYYYYGGGGGGGGGGGGGGGGGGGWHHWDDDDDDDDDTTTOOBBBBBBBBBEEEEEEEEEEBGGGBPENNNSSNNNNNNNNNNNNNNUNNNKKKKKNK\r\nGGGGVVVVVVVVVVVYYYDDDDDDDDDUUUSSUUSSSSSSSSSYYYGGGGGGGGGGGGGGGGGGGGWDDDDDDNNDDDDTTTTTBBBBBBBBBEEEEEEEEEEGGGGGEEESRSNNNNJTTNNNNNNNNNNNNKKKKKKK\r\nGGGGVVVVVVVVVVVYYYYYDDDDDDUUUUUUUUSSSSSSSSYYYYGGGGGGGGGGGGGGGGGGGGDDDDNNNNNNDTTTTTTTBBBBBBBBBEEEEEEEEEEHHRSSSSSSSSSNYYTTTNNNNNNNNNNNKKKKKKKK\r\nVGVVVVVVVVVYYYVYYYYYDDDDDDUUUUUUUUUSSSSSSSYYYYGGGGGGGGGGGGGGGGGGGGGDBWNNNNNNNTTTTTTTBBBBBBBBBEEEEEEEEEEHHHSSSSSSSSSYYYTTTNRRNNNNNKKNKKKKKKKK\r\nVVVVVVVVVVVVYYYYYYYYYYDLLDUUUUUUUUUUUSSSSSYYYYGGGGGGGGGGRGYGGGGBBGGBBBNNNNNNNTTTTTTTTTWWXXXHXEEEEEEEEEEHSHSSSSSSSSSSSYYTTTRRRNNNNNKKKNKKKKKK\r\nWVVVVVVVVVYYYYYYYYYYYYDLZUUUUUUUUUUUUSSSSSYYYYGGYGGGGGGGRRYGBBBBGGGBQQNNNNNNNTTTTTTTWWWXXXXHTEEEEEEEEEEHSSSSSSSSSSSSSYTTTTRRRNSSNNKKNNNKKKKK\r\nWVVVVVVVVVYYYYYYYYYYYQDLZZUUUUUUUUUUUSSSSSXYYYYYYYGVVGSGRRYRBBBBBBBBBBNNNNNNNNTTTTTTWHHHRHPHTEEEEEEEEEEHSSSSSSSSSSSSSSSRTRRNNNSSNNNNNNNKKKKK\r\nVVVVVVVVVYYYYYYYYYYYYQLLLLUUUUUUUUUIISSSSXXYYYYYYYGVRGSRRRRRBBBBBBBBNNNNNNNNNTTTTTTHWHHHHHPHHEEEEEEEEEESSSSSSSSSSSSSSSRRRRCCNNNSSCNNNNNNKKKK\r\nIVVJVVVVVJJJYYYYYYYYDLLLLLLWWWUUUUUIIIYSSXXXYYYYYYYRRBRRRRSSBBBBBBBBBBNNNNNNXXXXXXXHHHHHHHHHHEEEEEEEEEESSSSSSSSSSSSSSRRRRRRCCCCSCCNNNNNKKKKK\r\nKKKVVKVVVVVJJYYYYYYYYYYLLLLLWWUUMMMMMIYQXXXXYYYYYYRRRRRRRRRBBBBBBBBBBBNNNNNMXXXXXXXHHHHHHHHHHEEEEEETTTTHNNNSNSSSSSSSSSSRRRRCCCCCCCCCCNNNNKKK\r\nKKKVKKVVVVVJJYYJYYYYDLLLLLLLWWYYYYYYYYYYYYYYYYYYYYRRRRRRRRRRBBBBBBBBBBBNNMNNXXXXXXXXXXXXHHHHHHEEEEETTHHHNNNNNSSSSHSHSHHHHHHCCCCCCCNNNNNNQKMM\r\nKKKKKKKVVVVJJJJJYYYYYLLTLLLLLLYYYYYYYYOYYYYYYYYYYYRRRRRRRRRDBBBBBBBBBBBNNMMMXXXXXXXXXXXXHHHHHHEEEEETTHHHNNNNNNNSSHHHSHHHHHHCCCCCCCNNMMNMQMMM\r\nFKKKKKKKKKJJJJJJYYYYYYYTTLLLLLYYYYYYYYYYYYYYYYYYYYRRRRRRRRRDBBBBBBBBBBNNMMMMXXXXXXXXXXXXHHHHHHEEEEETTHHHHNNNNNNNHHHHHHHHHHHHCCCCCCCNNMMMMMMM\r\nFFFKKKKKKKJJJJJJJTYBTTVTTZLVVVYYYYYYYYUYYYYYYYYYYYYRRRRRRRBBBBYBBBBBBBNMMMMMXXXXXXXXXXXXHHHHHHEEEEETTTHHHHNNNNNNHHHHHHHHHHHHCCCCCCCNNNMMMMMM\r\nFKKKKKKKKKKJJJJJJTTTTTTTVVVVVNYYYYYYYYUYYYYYYYYYYYYYRYYRRYYYYYYBBBBBBNNMMMMMXXXXXXXXXXXXHHHEEEEEEEEZTTHNHHNNNNNNNNNHHHHHHHHCCCCCCCCNNNMNMMMM\r\nFFKKKKKKKJJJJJJTTTTTTTTTVVVVVVYYYYYYYYUUUUYYYYYYYYYYYYYYYYYYYYYBBBBBBBBMMMMMXXXXXXXXXXXXHHEEEEEEEEEZTTNNNHNNNNNNNNNHHHHHHHHCCCCCCCCNNNNNLLLM\r\nFFFKKAAAJJJJJJJTTTTTTTTTVVVVVVYYYYYYYYUUUUYUUYYYYYYYYYYYYYYYYYYBBBBBBBBBMMMMTTXXXXXXXXXXEHEEEEEEEEEZZZNNNNNNNNNNNNNHHVVHHHCCCCCCCCNNNNNNLLLM\r\nFFFKKAAAAJAJJTTTTTTTTTTTVVVVVVYYYYYYYYUUUUUUUYRRRRRYYYYYYYYYYYYBBBBBBBBBMMMMTTXXXXXXXXXXEEEEEEEEEEEZZZNNNNNNNNNNNNNHHVVVHLCCQQNNCNNNNNLLLLLO\r\nFFFABAAAAAAJTTTTTTTTTTTTVVVVVVYYYYYYYYUUZZZUUZRRRYYYYYYYYYYYYYYYBBBBBBBTTTTTTTXXXXXXXXXXEEEEEEEEEEEZZZXZNNNNNNNNNANNNVVVVVCQQQQNNNNNNLLLLLLL\r\nFFAAAAAAAATJTTTTTTTTTTTGVVVIIVYYYYYYYYZZZZZZZZRRRYYYYYYYYYYYYYYZZBBBBBBBBBBBTTXXXXXXXXXXTEEEEEEEEEEZZZZZNNNNNNNNNNNNVVVVVVQQQQQQNNNNNLLLLLLL\r\nFAAAAAAAAATTTTTTTTTTTTTVVVIIIVVVVUUUUUZZZZZZZZRRYYYYYYYYYYYYYYYZZZBBBBBBBBBBTTTTTTTTTTTTEEEEEEEEEEEZZZZZNNNNNNNNNNNVVVVVVFFQQQQQNNNNNLLLLLLL\r\nFAAAAAAAAAATTTTTTTTTTTTTVVIIIUUUUUUUUUUZZZZMMMMYYYKYYYYKYYYYYYYYYYBBBBBBBBBTTTTTTTQTTTTTTEEEEEEEEEEZZZZZNNNNNNNNNNVVVVVVVFFFQFQQNNNNNNLLLLLL\r\nAAAAAAAATTATTTTTTTTTTTTUVVVIUUUUUUUUUUUZMMMMMMYYYYKKKKKKKYYYYBBBBBBBBBBBBBTTQTTQQQQQTTTTTTEZZZZZZZZZZZZZZNNNNNNSSSVVVVVFFFFFFFFQNNIIOIIILLLL\r\nAAAAAAAAATTTTTTTTTTTTTTUUIIIIUUUUUUUUURZMMMMMMYMMYKKKKEEYYYYYBBBBBBBBBBBDQQTQQQQQQQQQTTTTTKZZZZZZZZZZZTZZNNNSSSSSSVVVVVFFFFFFFFIIIIIIIILLLLL\r\nAAAAAAAAAATTSTYTTHHTTTUUUIMIIUUUUUUUUUUUUMMMMMMMMKKKKKEKKKKKBBBBBBBBDDDDDQQQQQQQQQQQQQQQQQQQZZZZZZZZZTTNNNNSSSSSSSVVVVFFFFFFFFBIIIIIIIIILLLL\r\nAAAAAAAAAASSSHTTTHHTOAAUUIIIUUUUUUUUUUUUUMMMMMMMKKKKKKKKKKKBBCCBBBBBDDDDDDQQQQQQQQQQQQQQQQUDZZZZUUZZZTNNNVNNSSSSSSSEVVVFFJFGFFBBBIIIIILLLLLL\r\nAAAAAAAAAAAHHHHHHHHHAAAUUUUUUUUUUUUUUUUUUMMMMMMMKKKKKKKKKKBBBCCCBCBBBDDDDQQQQQQQQQQQQQQQCUUUUUZUUUUUZUUNNSSSSSSSSSSSVVVVVJJQQQQQBIIHIILLLLLL\r\nAAAAAAAPPAPHHHHHHHHHHEAFUFFUUUUUUUAUUUUUUMMMUMMMMMKKKKKKKKBBBCCCBCCBDDDDDDQPQQQQQQQQQPPUCUUUUUUUUUUUZUUUUFUUSSSSSSSSSSSOQJQQQQQQBIHHHLLLLLLL\r\nAAAQAAAPPPPHHHHHHHHHHHAFFFAFUAUUUUAUUUUUUUUUUMMUZMKKKKKKKKBCCCTCCCCCCPDDDDPPQQQQQQQQQPPUUUUUUUUUUUUUUUUUUUUUSSSSSSSSSOSOQQQQQQQQQIHHHLLLLLLL\r\nAAAAAAAPPPPHPPHHHHHAAAAAFFFFAAAAUUUUUUUUUUUUUMUUUUKKKKKKKKCCCCCCCCCCCPPDDDPPPPQQQQQQQPPUUUUUUUUUUUUUUUUUUUUSSSSSSSSSSOOOOOQQQQQQQQQHHLLLLLLL\r\nAPAAAAAPPPPPPPHHHHHAAAAAFFFAAAAAUUUUUUUUUUUUUUUUUUUKKKKKKCCCCCCCCCCCPPPPPPPPPPPQPPPQQPPPPUUPPUUUUUUUUUUUUUUSSSSSSSSSSOOOOOOQQQQQQQQHHLLLLLLL\r\nPPPAAPPPPPPPPPHHHAHAAAAAAAFAAAAAUUUUUUUUUUUUUUUUUKKKKKKKKCCCCCCCCCCCCPPPPPPPPPPPPPPPPPPPPPPPPUUUUUUUUUUUUUUSSSSSSSSSSSOOQQQQQQQQQQQQHHLLLULL\r\nPPPPPPPPPPPPPHHHHAAAAAAAAAAAAAAAAUUUUUUUUUUUUUUUUKKKKKKKKKCCCCCCCCCCCCPPPPPPPPPPPPPPPPPPPPPPUUUUUUUUUUUUUUSSSSSSSSSSSSOQQQQQQQQQQQQQHHLLUULL\r\nPPPPPPPPPPPPPPHQHAAAAAAAAAAAAAAATTTUUUUUUUUUUUUUUKKKKKKKKKKCCCCCMMCPPPPPPPPPPPPPPPPPPPPPPPPPUUUUUUUUYUUUUUUSSSSSSSSSSSQQQQQQQQQQQKKQHHLUUUUU");
        }
        public static Matrix<char> GetSimpleTrainingDataPartOne()
        {
            return MatrixParser.Parse("OOOOO\r\nOXOXO\r\nOOOOO\r\nOXOXO\r\nOOOOO");
        }
        public static Matrix<char> GetTrainingData()
        {
            return MatrixParser.Parse("RRRRIICCFF\r\nRRRRIICCCF\r\nVVRRRCCFFF\r\nVVRCCCJFFF\r\nVVVVCJJCFE\r\nVVIVCCJJEE\r\nVVIIICJJEE\r\nMIIIIIJJEE\r\nMIIISIJEEE\r\nMMMISSJEEE");
        }
        public static Matrix<char> GetTrainingDataPartTwo()
        {
            return MatrixParser.Parse("AAAAAA\r\nAAABBA\r\nAAABBA\r\nABBAAA\r\nABBAAA\r\nAAAAAA");
        }
    }
}
