using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

static public class BasementSaveSystem
{
    private static readonly uint buildVersionMajor = 1;
    private static readonly uint buildVersionMinor = 0;
    private static readonly string fileExt = ".oaf";

    public enum Code
    {
        SUCCESS,
        SAVE_FILE_NOT_FOUND,
        VERSION_MISMATCH,
        INVALID_FILE_DATA
    }

    // These ID names should reflect the most recent basement visited by the
    //  player. The entries are subject to change (any behavioral code, like
    //  switch statements, etc. should be adjusted proportionally).
    [System.Serializable]
    public enum BasementSerialID
    {
        BASEMENT_Beginning,
        BASEMENT_Memories,
        BASEMENT_PostDance,
        BASEMENT_AllGood,
        BASEMENT_NotGood,
        BASEMENT_BackToNormal
    }

    // Model for a binary file holding data for basement ID tracking/saving.
    [System.Serializable]
    private struct BasementSerialFileData
    {
        public BasementSerialID bID;
        public uint versionMajor;
        public uint versionMinor;
    }

    public static Code SaveBasement(string saveName, BasementSerialID basementID)
    {
        // prepare information to be serialized
        BasementSerialFileData fileData;
        fileData.versionMajor = buildVersionMajor;
        fileData.versionMinor = buildVersionMinor;
        fileData.bID = basementID;

        // open save file and prepare a binary writer
        System.IO.FileStream saveFile = System.IO.File.OpenWrite(saveName + fileExt);
        System.IO.BinaryWriter bw = new System.IO.BinaryWriter(saveFile);

        // write fileData fields individually (very stupid, and a maintainance hurdle)
        bw.Write((uint)fileData.bID);
        bw.Write(fileData.versionMajor);
        bw.Write(fileData.versionMinor);

        bw.Close();
        saveFile.Close();

        return Code.SUCCESS;
    }

    public static Code LoadBasement(string saveName)
    {
        Code ret = Code.SUCCESS;

        if(System.IO.File.Exists(saveName + fileExt))
        {
            // open save file and prepare a binary reader
            System.IO.FileStream saveFile = System.IO.File.OpenRead(saveName + fileExt);
            System.IO.BinaryReader br = new System.IO.BinaryReader(saveFile);

            // read fileData fields individually (very stupid, and a maintainance hurdle)
            BasementSerialFileData fileData;
            fileData.bID = (BasementSerialID)br.ReadUInt32();
            fileData.versionMajor = br.ReadUInt32();
            fileData.versionMinor = br.ReadUInt32();

            br.Close();
            saveFile.Close();

            // check version
            if (fileData.versionMajor == buildVersionMajor &&
                fileData.versionMinor == buildVersionMinor)
            {
                switch(fileData.bID)
                {
                    case BasementSerialID.BASEMENT_Beginning:
                        {
                            SceneManager.LoadScene("Basement0");
                        } break;
                    case BasementSerialID.BASEMENT_Memories:
                        {
                            SceneManager.LoadScene("Basement1");
                        } break;
                    case BasementSerialID.BASEMENT_PostDance:
                        {
                            SceneManager.LoadScene("Basement2");
                        } break;
                    case BasementSerialID.BASEMENT_AllGood:
                        {
                            SceneManager.LoadScene("Basement3");
                        } break;
                    case BasementSerialID.BASEMENT_NotGood:
                        {
                            SceneManager.LoadScene("Basement4");
                        } break;
                    case BasementSerialID.BASEMENT_BackToNormal:
                        {
                            SceneManager.LoadScene("Basement5");
                        } break;
                    default:
                        {
                            ret = Code.INVALID_FILE_DATA;
                        } break;
                }
            }
            else
            {
                ret = Code.VERSION_MISMATCH;
            }
        }
        else
        {
            ret = Code.SAVE_FILE_NOT_FOUND;
        }

        return ret;
    }

}
