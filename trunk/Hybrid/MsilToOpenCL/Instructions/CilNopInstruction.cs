﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;

namespace Hybrid.MsilToOpenCL.Instructions
{
    public class CilNopInstruction : CilInstruction
    {
        public static CilInstruction Create(OpCode Opcode, byte[] IL, int Offset, int NextOffset, MethodBase ParentMethodBase)
        {
            return new CilNopInstruction(Opcode, Offset);
        }

        private CilNopInstruction(OpCode Opcode, int Offset)
            : base(Opcode, Offset)
        {
            if (Opcode != OpCodes.Nop)
            {
                throw new ArgumentException("Opcode");
            }
        }

        public override void WriteCode(System.IO.TextWriter writer, int indent, int CurStack)
        {
            WriteInstHeader(writer, indent);
            writer.WriteLine("{0}// CIL NOP", IndentString(indent));
        }

        public override List<HighLevel.Instruction> GetHighLevel(HighLevel.HlGraph Context)
        {
            return new List<HighLevel.Instruction>();
        }
    }
}
